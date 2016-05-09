using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afkagain
{
    class Renderer
    {
        public class VBO<T>
        {
            public int id;
            public T[] array;
            public Type type = typeof(T);
            public VBO(int id, T[] array) {
                this.id = id;
                this.array = array;
            }
        }
        public Action swapBuffers;
        public Matrix4 modelView;
        public Matrix4 projection;
        public Matrix4 guiMatrix;
        public Renderer(Action bufferSwap)
        {
            swapBuffers = bufferSwap;
        }
        public void Start()
        {
            GL.Viewport(0, 0, 1280, 720);
            projection = Matrix4.CreatePerspectiveFieldOfView(0.6f, Game.size.Width / Game.size.Height, 0.1f, 1000f);
            guiMatrix = Matrix4.CreateOrthographic(1, 1, -1, 1);
        }
        public void UpdateSky()
        {
            float l = Sky.perc;
            Vector3 day = new Vector3(135f / 255f, 206f / 255f, 235f / 255f);
            Vector3 night = new Vector3(0, .05f, .1f);
            Vector3 skyColor = Mathe.lerp(day, night, l);
            GL.ClearColor(skyColor.X, skyColor.Y, skyColor.Z, 1);
        }
        protected VBO<Vector3> CreateVector3Buffer(Vector3[] array)
        {
            int vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(Vector3.SizeInBytes * array.Length), array, BufferUsageHint.DynamicDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            return new VBO<Vector3>(vbo, array);
        }
        protected int CreateIndexBuffer(int[] array)
        {
            int vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, new IntPtr(Vector3.SizeInBytes * array.Length), array, BufferUsageHint.DynamicDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            return vbo;
        }
        protected void RenderVBO(VBO<Vector3> vectors, VBO<Vector3> normals, VBO<Vector2> uvs, int indexBuffer)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, vectors.id);
            GL.VertexPointer(vectors.array.Length, VertexPointerType.Float, Vector3.SizeInBytes, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, normals.id);
            GL.NormalPointer(NormalPointerType.Float, Vector3.SizeInBytes, normals.array);
            GL.BindBuffer(BufferTarget.ArrayBuffer, uvs.id);
            GL.TexCoordPointer(vectors.array.Length, TexCoordPointerType.Float, Vector3.SizeInBytes, uvs.array);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexBuffer);
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.NormalArray);
            GL.EnableClientState(ArrayCap.TextureCoordArray);
           
            GL.DrawElements(PrimitiveType.Triangles, vectors.array.Length, DrawElementsType.UnsignedInt, 0);
        }
        public void Render(float delta)
        {
            UpdateSky();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            OnWorldRender();
            OnGUIRender();
            swapBuffers();
        }
        
        protected void OnWorldRender()
        {
            GL.LoadMatrix(ref modelView);
        }
        protected void OnGUIRender()
        {
            GL.LoadMatrix(ref guiMatrix);
        }
    }
}
