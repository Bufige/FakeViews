using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FakeViews
{
	class MainClass
	{
		private static Browser test;
		public static void Main(string[] args)
		{


			int[] temp = { 10, 15, 20, 30 }; // tempo exemplo
			test = new Browser("https://soundcloud.com/parkway-drive"); //página pra dar view.


			int views = 0; //contador de views aumentado.

			while (true && test.Count > 0)
			{
				Random tempo = new Random();
				Random musica = new Random();
				int m = musica.Next(0, test.Count);
				int t = temp[tempo.Next(0, temp.Length)] * 1000; 
				views++;

				test.Play(m);
				Console.WriteLine("Musica {0} por tempo {1}s",m,t/1000);
				Console.WriteLine("Views: " + views);
				Thread.Sleep(t);

			}

		}
	}
}
