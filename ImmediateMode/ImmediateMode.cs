/*************************************************
            HATNEAN LAVINIA, 3131a
*************************************************/
using System;
using System.Drawing;
using System.IO;
using System.Security.Policy;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace OpenTK_immediate_mode
{
    class ImmediateMode : GameWindow
    {
        private int[] vec = new int[20];
        private int OK = 1;
        private int OK2 = 2;

        private const int XYZ_SIZE = 75;

        public ImmediateMode() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            Console.WriteLine("OpenGl versiunea: " + GL.GetString(StringName.Version));
            Title = "OpenGl versiunea: " + GL.GetString(StringName.Version) + " (mod imediat)";

        }

        /**Setare mediu OpenGL și încarcarea resurselor (dacă e necesar) - de exemplu culoarea de
           fundal a ferestrei 3D.
           Atenție! Acest cod se execută înainte de desenarea efectivă a scenei 3D. */
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Blue);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);

            /*
             Laborator 3-citire date din fisier
             */
            string linie;
            char[] sep = { ',' };
            int i = 0;

            StreamReader f = new StreamReader("date.txt");
            while ((linie = f.ReadLine()) != null)
            {
                string[] numere = linie.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                foreach (string x in numere)
                    vec[i++] = int.Parse(x);

            }
        }

        /**Inițierea afișării și setarea viewport-ului grafic. Metoda este invocată la redimensionarea
           ferestrei. Va fi invocată o dată și imediat după metoda ONLOAD()!
           Viewport-ul va fi dimensionat conform mărimii ferestrei active (cele 2 obiecte pot avea și mărimi 
           diferite). */
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);


        }
        ///LABORATOR 2
        /** Secțiunea pentru "game logic"/"business logic". Tot ce se execută în această secțiune va fi randat
            automat pe ecran în pasul următor - control utilizator, actualizarea poziției obiectelor, etc. 
        Prin apasarea tastei sageata dreapta, axele se vor muta la dreapta, prin apasarea tastei sageata stanga, 
        axele se vor muta la stanga, iar prin apasare click dreapta axele vor reveni in poxitia initiala*/
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();
            if (keyboard[Key.Right])
            {
                base.OnResize(e);

                GL.Viewport(100, 100, Width, Height);
            }
            if (keyboard[Key.Left])
            {
                base.OnResize(e);

                GL.Viewport(-100, -100, Width, Height);
            }
            if (mouse[MouseButton.Right])
            {
                base.OnResize(e);

                GL.Viewport(0, 0, Width, Height);
            }
            if (keyboard[Key.Escape])
            {
                Exit();
            }
        }

        /** Secțiunea pentru randarea scenei 3D. Controlată de modulul logic din metoda ONUPDATEFRAME().
            Parametrul de intrare "e" conține informatii de timing pentru randare. */
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            DrawAxes();
            DrawObjects();

            // Se lucrează în modul DOUBLE BUFFERED - câtă vreme se afișează o imagine randată, o alta se randează în background apoi cele 2 sunt schimbate...
            SwapBuffers();
        }

        private void DrawAxes()
        {

           
            // Desenează axa Ox (cu roșu).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(XYZ_SIZE, 0, 0);
           

            // Desenează axa Oy (cu galben).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Yellow);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, XYZ_SIZE, 0); ;
           

            // Desenează axa Oz (cu verde).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, XYZ_SIZE);
            GL.End();
        }

        private void DrawObjects()
        {
            KeyboardState keyboard = Keyboard.GetState();

            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(1.0, 0.0, 0.0);


            /*
             * Rezolvare Laborator 3
             */
            //la apasarea tastei sus triunghiul isi va schimba culoarea cu rosu
            if (keyboard[Key.Up])
            {
                if (OK == 255)
                    OK = 1;
                OK++;

                GL.Color3(Color.FromArgb(OK, 0, 0));
                Console.WriteLine(OK); //afisare valori RGB in consola
            }
            GL.Vertex3(vec[0], vec[1], vec[2]);

            //la apasarea tastei jos triunghiul isi va schimba culoarea cu verde
            if (keyboard[Key.Down])
            {
                if (OK == 255)
                    OK = 1;
                OK++;
                GL.Color3(Color.FromArgb(0, OK, 0));
                Console.WriteLine(OK);

            }
            //la apasarea sagetii stanga se va schimba cu culoarea albastra
            GL.Vertex3(vec[3], vec[4], vec[5]);
            if (keyboard[Key.Left])
            {
                if (OK == 255)
                    OK = 1;
                OK++;
                GL.Color3(Color.FromArgb(0, 0, OK));
                Console.WriteLine(OK);

            }
            GL.Vertex3(vec[6], vec[7], vec[8]);
            if (keyboard[Key.Right])
            {
                if (OK2== 255 || OK == 255)
                    OK2 = OK = 0;
                OK2++;
                OK++;
                GL.Color3(Color.FromArgb(OK2, 0, 255, 0));
                Console.WriteLine(OK2);

            }

            GL.End();

            GL.Begin(PrimitiveType.LineStrip);
            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex3(0.0, 10, 0.0f); //vertex 1
            GL.Color3(0.0, 0.0, 0.0);
            GL.Vertex3(0.0f, 0.0f, 0.0f); //vertex 2
            GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex3(10, 10, 0.0f); //vertex 3
            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex3(15, 0.0f, 0.0f); //vertex 4
            GL.End();

        }


        [STAThread]
        static void Main(string[] args)
        {

            /**Utilizarea cuvântului-cheie "using" va permite dealocarea memoriei o dată ce obiectul nu mai este
               în uz (vezi metoda "Dispose()").
               Metoda "Run()" specifică cerința noastră de a avea 30 de evenimente de tip UpdateFrame per secundă
               și un număr nelimitat de evenimente de tip randare 3D per secundă (maximul suportat de subsistemul
               grafic). Asta nu înseamnă că vor primi garantat respectivele valori!!!
               Ideal ar fi ca după fiecare UpdateFrame să avem si un RenderFrame astfel încât toate obiectele generate
               în scena 3D să fie actualizate fără pierderi (desincronizări între logica aplicației și imaginea randată
               în final pe ecran). */
            using (ImmediateMode example = new ImmediateMode())
            {
                example.Run(30.0, 0.0);
            }
        }
    }

}
