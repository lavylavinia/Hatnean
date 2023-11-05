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

#Laborator 3- Hatnean Lavinia 3131a

<p>1. Ordinea de desenare a vertexurilor este in sens anti-orar.</p>
<p>3. -GL.LineWidth(float) mărește diametrul liniei
-GL.PointSize(float)- precizeaza diametrul punctului
Aceste comenzi functioneaza in interiorul unei
zone GL.Begin(), nu si in afara ei. </p>

> 4. Intrebari

<p>4.1. Directiva LineLoop creaza o legatura intre segmentele desenate pana cand ultimul segment este unit cu primul (efect de bucla)</p>
<p>4.2. Directiva LineStrip creaza o legatura intre segmentele desenate astfel incat dupa fiecare doua segmente desenate se specifica un vertex de legatura.</p>
<p>4.3. Directiva TriangleFan deseneaza tringhiuri sub forma circulara.</p>
<p>4.4. Directiva TriangleStrip deseneaza pe ecran triunghiuri conectate intre ele, iar dupa ce s-au dat 3 vertexuri pentru crearea triunghiului se specifica un vertex.</p>
<p>Gradientul de culoare reprezintă o paleta de culori care evidențiază trecerea de la o culoare
la alta. În OpenGL acest lucru se realizează prin specificarea culorii vertex-urilor ce compun o
anumită figură. </p>
<p>8. Canalul de transparenta este o valoare pe 32 de biți de la 0 unde este complet transparent si la 255 unde este complet opac</p>
<p>10. Utilizarea culorilor diferite la vertexuri invecinate duce la crearea unui gradient pe acea dreapta.</p>


