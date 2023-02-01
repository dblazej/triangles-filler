# triangles-filler/wypełnianie-trójkątów
Wypełnianie siatki trójkątów w C# Windows Forms. <br/>
Program wykonany jako projekt uniwersytecki na Politechnice Warszawskiej.

![app1](https://user-images.githubusercontent.com/123904190/216015025-32ba3a13-f849-41b4-a40a-07f5b3110160.png)

## Podgląd video:

https://user-images.githubusercontent.com/123904190/216014755-cdb1162d-6e49-4bfc-88b4-09d0dc6af661.mp4

## Podstawowa specyfikacja:
<ul>
							Siatka trójkątów dana jest jako rzut prostokatny (na płaszczyznę xy) dowolnej triangulowanej
							powierzchni wczytywnanej z pliku (własny lub istniejący format - np. *.obj).
							Format pliku powinien zawierać współrzędne x,y,z wierzchołków oraz wektory normalne
							(nx,ny,nz) w wierzchołkach.<br>
							Opisywana powierzchnia musi być funkcyjna (z=f(x,y)).<br><br>

							Jedną z powierzchni do wczytywania musi być dodatnia półkula (oś z od ekranu do obserwatora)
							o środku w środku ekranu (picturebox/canvas/...) i takim promieniu, aby rzut kuli mieścił
							się na ekranie<br>
							<img src="2/siatka_kula.png" height='400px' width='400px'><br><br>
							</li>
							<li>
								Wypełniamy każdy trójkąt według poniższych zasad:<br><br>
							</li>
							<ul>
								<ol>
									<li>
										Algorytm wypełniania wielokątów/trójkątów:<br>
										&emsp;z sortowaniem krawędzi (kubełkowym) - <b>(osoby o nazwiskach od L do
											Z)</b><br>
										&emsp;z sortowaniem wierzchołków - <b>(osoby o nazwiskach od A do K)</b><br><br>
									</li>
									<li>
										Kolor wypełniania I:<br>
										Składowa rozproszona rmodelu oświetlenia (model Lamberta) +składowa
										zwierciadlana :
										&emsp;<strong>
											<h4>I = k<sub>d</sub>*I<sub>L</sub>*I<sub>O</sub>*cos(kąt(N,L)) +
												k<sub>s</sub>*I<sub>L</sub>*I<sub>O</sub>*cos<sup>m</sup>(kąt(V,R))
										</strong></h4><br>
										<img src="2/phong.png" height='200px'><br>
										(równanie oświetlenia raktujemy jako 3 niezalezne równania dla każdej składowej
										R,G,B koloru)<br>
										(cosinus kąta liczymy z iloczynu skalarnego wersorów N i L , np. cos(kąt(N,L)) =
										N<sub>x</sub>*L<sub>x</sub>+N<sub>y</sub>*L<sub>y</sub>+N<sub>z</sub>*L<sub>z</sub>
										)<br>
										&emsp;k<sub>d</sub> i k<sub>s</sub> - współczynniki opisujące wpływ danej
										składowej na wynik (0 - 1)<br>
										&emsp;I<sub>L</sub>(kolor światła) - możliwość wyboru z menu -> domyślnie kolor
										biały (1,1,1) <br>
										&emsp;I<sub>O</sub>(kolor obiektu) <br>
										&emsp;L (wersor do światła)<br>
										&emsp;N (Wektor normalny ) po wyznaczeniu musi on zostać znormalizowany do
										długości 1 (wersor)<br>
										&emsp;V=[0,0,1], <b>R=2&ltN,L&gtN-L</b> gdzie &ltN,L&gt - iloczyn skalarny
										wersorów N i L<br>
										&emsp;m - współczynnik opisujący jak bardzo dany trókat jest zwierciadlany
										(1-100)<br><br>

										<b>Uwaga</b><br>
										&emsp; - jeśli cosinusy we wzorze wychodzą ujemne -> przyjmujemy wartości 0!<br>
										&emsp; - obliczenia wykonujemy dla wartości kolorów z przedziału 0..1, dopiero
										ostateczny wynik konwerujemy do przedziału 0..255 (obcinając do 255)<br><br>

									</li>

									<li>
										Kolor wypełnienia punktu wewnątrz trójkąta może być wyznaczany - radiobuttons:
										<br>
										&emsp;albo wyznaczany tylko w wierzchołkach trójkątów a potem interpolowany 'do
										wnętrza'<br>
										&emsp;albo wyznaczany dokładnie w punkcie interpolując wektory normalne 'do
										wnętrza'<br>
										<b>Uwaga</b><br>
										&emsp;Do interpolacji (kolorów lub wektorów normalnych) używamy współrzędnych
										barycentrycznych punktu wewnątrz trójkata<br><br>
									</li>

									<li>
										współczynniki kd, ks i m: <br>
										&emsp;podane jednakowe dla wszystkich trójkątów (suwaki)<br><br>
									</li>

									<li>
										Żródło światła - animacja (z opcja zatrzymania) ruchu po spirali na pewnej
										płaszczyźnie z=const (z - suwak)<br><br>

									<li>
										I<sub>O</sub>(kolor obiektu) - radiobuttons: <br>
										&emsp;albo stały wybrany z menu<br>
										&emsp;wczytywana tekstura (obraz) całego 'panelu' -> domyślnie pewna
										tekstura<br><br>
									</li>

									<li>
										Powinna istnieć możliwość (checkbox) modyfikacji wektora normalnego na podstawie
										wczytanej mapy wektorów normalnych.<br>
										Zmodyfikowany wektor normalny: <b>N = M*N<sub>tekstury</sub></b><br>
										&emsp;&emsp;N<sub>tekstury</sub> - wektor normalny(wersora) odczytany z koloru
										tekstury (NormalMap) dla całego 'panelu', <b></b>Nx=<-1,+1>, Ny=<-1,+1>, Nz=
												<0,+1>
													</0>b><br>
													&emsp;&emsp;M - macierz przekształcenia (obrotu) dla wektora z
													tekstury:<br>
													&emsp;&emsp;&emsp;&emsp;M<sub>3x3</sub> = [T, B,
													N<sub>powierzchni</sub>]<br>
													&emsp;&emsp;&emsp;&emsp;&emsp;B (wersor binormalny) =
													N<sub>powierzchni</sub> x [0,0,1] (iloczyn wektorowy). Jeśli
													N<sub>powierzchni</sub>=[0,0,1] to B = [0,1,0]<br>
													&emsp;&emsp;&emsp;&emsp;&emsp;T (wersor styczny) = B x
													N<sub>powierzchni</sub> (iloczyn wektorowy)<br>
													&emsp;&emsp;N<sub>powierzchni</sub> - wektor normalny(wersor)
													odczytany/wyliczony z powierzchni<br>
													<img src="2/tangent_space.png" height='200px' width='200px'><br><br>

													Możliwość zmiany (wczytania) domyślnej tekstury/mapy wektorów
													normalnych <br><br>
													Przykładowe mapy wektorów normalnych (NormalMap):<br>
													<img src="brick_normalmap.png" height='100px' width='100px'><img
														src="normal_map.jpg" height='100px' width='100px'><br>
													(np. RGB(127,127,255) => N=[0,0,1]) <br><br>
									</li>
								</ol>
							</ul>
						</ul>

## Instrukcja obsługi:
Korzystając z programu wszystko wykonujemy przez kontrolki w oknie.
