#Laborator 2- Hatnean Lavinia 3131a
>1. MatrixMode.Projection
<p>Daca modificam valoarea constantei MatrixMode.Projection se modifica perspectiva din care utilizatorul priveste scena.</p>

> 3. Intrebari
<p>1. Un viewport reprezinta o zona exprimata prin coordonate specifice in care este desenata si afisata grafica 3D. </p>
<p>2. Conceptul de Frames per Second (FPS) reprezinta unitatea de masura pentru rata de  cadre, adica frecventa la care apar cadrele pe ecran. Pentru o grafica performanta este important numarul de cadre pe secunda, deoarece aceasta trebuie sa fie cat mai optim. </p>
<p>3. Metoda OnUpdateFrame() este apelata intre randarea actuala si cea urmatoare. Ea realizeaza actualizarea aplicatiei. </p>
<p>4. Modul imediat de randare reprezinta o metoda de realizare a graficii prin care se afiseaza obiecte grafice prin comenzi individuale care specifica punctele, culorile si alte atribute grafice. Un exemplu este GL.Begin. Acest mod este costisitor si afecteaza performanta, dar este usor de inteles.
<p>5. Ultima versiune care acceptă modul imediat este OpenGL 4.6. </p>
<p>6. Metoda OnRenderFrame() este rulată atunci când dorim randarea scenei.
<p>7. Este nevoie sa executam cel putin o data metoda OnRenderFrame() pentru a initia afisarea si sa setam viewport-ul grafic.</p>
<p>8. Parametrii metodei CreatePerspectiveFieldOfView() reprezintă creearea unei perspective a proiectării unei matrici si a raportului de aspecte și distanțe plane apropiate și de vedere.