using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake
	{
	class Program
		{
		static void Main (string[] args)


			{

			//Console.SetWindowSize(Console.WindowWidth + 200,Console.WindowHeight + 200);
			//Console.SetBufferSize(1000,1000);
			Console.SetWindowSize(90,42);
			int[] xPosition = new int[50];
			xPosition[0] = 35;
			int[] yPosition = new int[50];
			yPosition[0] = 20;
			int appleXDim = 10;
			int appleYDim = 10;
			int applesEaten = 0;

			string userAction = "";




			decimal gameSpeed = 150;
			bool isGameOn = true;
			bool isWallHit = false;
			bool isAppleEaten = false;
			bool isStayInMenu = true;


			Random random = new Random();

			Console.CursorVisible = false;





			showMenu(out userAction);

			do
				{


				switch(userAction)
					{
					case "1":
					case "d":
					case "directions":

						Console.Clear();
						BuildWall();
						Console.SetCursorPosition(5,5);
						Console.WriteLine("1) Resize the console window");
						Console.SetCursorPosition(5,6);
						Console.WriteLine("			4 sides of playing field boarder");
						Console.SetCursorPosition(5,7);
						Console.WriteLine("2) Use the Arrow keays to move the snake around the field");
						Console.SetCursorPosition(5,8);
						Console.WriteLine("3) snake will die and you will loose if it hits the wall");
						Console.SetCursorPosition(5,9);
						Console.WriteLine("4) you gain points by eating the apple");
						Console.SetCursorPosition(5,10);
						Console.WriteLine("		but your snake will also go faster and get longer");
						Console.SetCursorPosition(5,12);
						Console.WriteLine("Press enter to return to main menu.");
						Console.ReadLine();
						Console.Clear();
						showMenu(out userAction);
						break;

					case "2":
					case "p":
					case "play":

						Console.SetCursorPosition(73,20);
						Console.WriteLine("Score:");
						Console.SetCursorPosition(79,20);
						Console.WriteLine(applesEaten);
						Console.SetCursorPosition(73,23);
						Console.WriteLine("Apples:");
						Console.SetCursorPosition(80,23);
						Console.WriteLine(applesEaten);

						Console.SetCursorPosition(xPosition[0],yPosition[0]);
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine((char)214);


						// set first a.pple on board

						settApplePositionOnScreen(random,out appleXDim,out appleYDim);
						paintApple(appleXDim,appleYDim);


						//build boundry
						BuildWall();

						//snake move

						ConsoleKey command = Console.ReadKey().Key;

						do
							{

							switch(command)
								{


								case ConsoleKey.LeftArrow:
									Console.SetCursorPosition(xPosition[0],yPosition[0]);
									Console.Write(" ");
									xPosition[0]--;
									break;
								case ConsoleKey.UpArrow:
									Console.SetCursorPosition(xPosition[0],yPosition[0]);
									Console.Write(" ");
									yPosition[0]--;
									break;
								case ConsoleKey.RightArrow:
									Console.SetCursorPosition(xPosition[0],yPosition[0]);
									Console.Write(" ");
									xPosition[0]++;
									break;
								case ConsoleKey.DownArrow:
									Console.SetCursorPosition(xPosition[0],yPosition[0]);
									Console.Write(" ");
									yPosition[0]++;
									break;

								}

							//paint snake
							//make snake longer
							paintSnake(applesEaten,xPosition,yPosition,out xPosition,out yPosition);







							//detect if snake hits wall
							//slow snake down

							isWallHit = DidsnakeHitWall(xPosition[0],yPosition[0]);
							if(isWallHit)
								{
								isGameOn = false;
								Console.SetCursorPosition(5,20);
								Console.WriteLine($"The snake hit the wall. Your snake ate {applesEaten} apples.GAME OVER. ");
								}


							//detect when apple is eaten

							isAppleEaten = determineIfApplewasEaten(xPosition[0],yPosition[0],appleXDim,appleYDim);




							//place apple of board (random)
							if(isAppleEaten)
								{

								settApplePositionOnScreen(random,out appleXDim,out appleYDim);
								paintApple(appleXDim,appleYDim);
								//count eaten apples

								applesEaten++;
								gameSpeed *= .925m;
								//count score
								Console.ForegroundColor = ConsoleColor.White;
								Console.SetCursorPosition(73,20);
								Console.WriteLine("Score:");
								Console.SetCursorPosition(79,20);
								Console.WriteLine((applesEaten * 100));
								Console.SetCursorPosition(73,23);
								Console.WriteLine("Apples:");
								Console.SetCursorPosition(80,23);
								Console.WriteLine(applesEaten);


								//make snake faster

								}


							if(Console.KeyAvailable)
								command = Console.ReadKey().Key;
							System.Threading.Thread.Sleep(Convert.ToInt32(gameSpeed));

							} while(isGameOn);




						break;

					case "3":
					case "e":
					case "exit":
						isStayInMenu = false;
						Console.Clear();
						break;


					default:
						Console.WriteLine("I didn't understood your input, please press enter and try again");
						Console.ReadLine();
						Console.Clear();
						showMenu(out userAction);
						break;
					}
				} while(isStayInMenu);

			Console.Read();


			}

		private static void showMenu (out string userAction)
			{
			string menu1 = "1) Directions\n2)Play \n3) Exit\n\n\n" + @"
		    ____
      _,.-'`_ o `;__,                
       _.-'` '---'  '

";
			string menu2 = "1) Directions\n2)Play \n3) Exit\n\n\n" + @"
				    ____
                 .'`_ o `;__,
       .       .'.'` '---'  '           
       .`-...-'.'
        `-...-'

";
			string menu3 = "1) Directions\n2)Play \n3) Exit\n\n\n" + @"
                        _,.--.
    --..,_           .'`__ o  `;__,
       `'.'.       .'.'`  '---'`  '        
          '.`-...-'.'
            `-...-'



";
			string menu4 = "1) Directions\n2)Play \n3) Exit\n\n\n" + @"
 --..,_						   _,.--.
       `'.'.                .'`__ o  `;__.     
          '.'.            .'.'`  '---'`  `
            '.`'--....--'`.'
              `'--....--'`

";







			Console.WriteLine(menu1);
			System.Threading.Thread.Sleep(250);
			Console.Clear();
			Console.WriteLine(menu2);
			System.Threading.Thread.Sleep(250);
			Console.Clear();
			Console.WriteLine(menu3);
			System.Threading.Thread.Sleep(250);
			Console.Clear();
			Console.WriteLine(menu4);
			System.Threading.Thread.Sleep(250);
			Console.Clear();

			userAction = Console.ReadLine().ToLower();




			}

		private static void paintSnake (int applesEaten,int[] xPositionIn,int[] yPositionIn,out int[] xPositionOut,out int[] yPositionOut)
			{
			//paint the head
			Console.SetCursorPosition(xPositionIn[0],yPositionIn[0]);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine((char)214);

			//paint the body

			for(int i = 1; i < applesEaten + 1; i++)
				{
				Console.SetCursorPosition(xPositionIn[i],yPositionIn[i]);
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("o");
				}

			//erase last part of snake
			Console.SetCursorPosition(xPositionIn[applesEaten + 1],yPositionIn[applesEaten + 1]);

			Console.WriteLine(" ");


			//record location of body part
			for(int i = applesEaten + 1; i > 0; i--)
				{
				xPositionIn[i] = xPositionIn[i - 1];
				yPositionIn[i] = yPositionIn[i - 1];

				}
			//return the new array
			xPositionOut = xPositionIn;
			yPositionOut = yPositionIn;


			}

		private static void BuildWall ( )
			{
			for(int i = 1; i < 41; i++)
				{
				Console.ForegroundColor = ConsoleColor.White;
				Console.SetCursorPosition(1,i);
				Console.Write("@");
				Console.SetCursorPosition(70,i);
				Console.Write("@");

				}
			for(int i = 1; i < 71; i++)
				{
				Console.ForegroundColor = ConsoleColor.White;
				Console.SetCursorPosition(i,1);
				Console.Write("@");
				Console.SetCursorPosition(i,40);
				Console.Write("@");

				}


			}






		private static void settApplePositionOnScreen (Random random,out int appleXDim,out int appleYDim)
			{
			appleXDim = random.Next(0 + 2,70 - 2);
			appleYDim = random.Next(0 + 2,40 - 2);

			}
		private static void paintApple (int appleXDim,int appleYDim)
			{
			Console.SetCursorPosition(appleXDim,appleYDim);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write((char)64);


			}

		private static bool DidsnakeHitWall (int xPosition,int yPosition)
			{
			if(xPosition == 1 || xPosition == 70 || yPosition == 1 || yPosition == 40)
				return true;
			return false;


			}
		private static bool determineIfApplewasEaten (int xPosition,int yPosition,int appleXDim,int appleYDim)
			{
			if(xPosition == appleXDim && yPosition == appleYDim)
				return true;
			return false;

			}

		}
	}
