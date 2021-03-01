using System;

namespace Operaciones_basicas
{
    class Program
    {
        static void Main(string[] args)
        {
            try
			{
				bool condition = true;
				
				do
				{
					int op;
					
					op = Menu();
					
					if(op != 5)
					{
						Operar(op);
					}
					else
					{
						condition = false;
					}
					
				}while(condition);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
        }
		
		public static int Menu()
		{
			for(int k = 0;;)
			{
				bool ejecutar = false;
				
				PintarMenu(k);
				ConsoleKeyInfo key = Console.ReadKey(true);
			
				switch(key.Key)
				{
					case ConsoleKey.UpArrow: k--; break;
					case ConsoleKey.DownArrow: k++; break;
					case ConsoleKey.Enter: ejecutar = true; break;
				}
				
				if(k < 0)k = 5;else if(k > 5) k = 0;
				
				if(ejecutar)
				{	
					Console.Clear();
					return k;
				}
			
			}
		}
		
		public static void PintarMenu(int k)
		{
			ConsoleColor menu = ConsoleColor.White;
			ConsoleColor selec = ConsoleColor.Yellow;
			ConsoleColor exit = ConsoleColor.Red;
			
			Console.ForegroundColor = ConsoleColor.White;
			Console.SetCursorPosition(4,1);
			Console.WriteLine("OPERACIONES BASICAS");
			
			Console.SetCursorPosition(4,4);
			Console.ForegroundColor = k == 0 ? selec:menu;
			Console.WriteLine("Suma");
			
			Console.SetCursorPosition(4,6);
			Console.ForegroundColor = k == 1 ? selec:menu;
			Console.WriteLine("Resta");
			
			Console.SetCursorPosition(4,8);
			Console.ForegroundColor = k == 2 ? selec:menu;
			Console.WriteLine("Multiplicacion");
			
			Console.SetCursorPosition(4,10);
			Console.ForegroundColor = k == 3 ? selec:menu;
			Console.WriteLine("Division");
			
			Console.SetCursorPosition(4,12);
			Console.ForegroundColor = k == 4 ? selec:menu;
			Console.WriteLine("Modulo");
			
			Console.SetCursorPosition(4,15);
			Console.ForegroundColor = k == 5 ? exit:menu;
			Console.WriteLine("Salir");
			
		}
		
		public static void Operar(int op){
			string num_1 = "";
			string num_2 = "";
			float numero_1 = 0;
			float numero_2 = 0;
			float respuesta;
			bool condition = true;
			
			Console.ForegroundColor = ConsoleColor.White;
			
			do
			{
				Console.SetCursorPosition(4,1);
				Console.WriteLine("Ingresa el primer numero");
				Console.Write(" .: ");
				
				if(num_1.Equals(""))
				{
					num_1 = Console.ReadLine();
					
					if(!float.TryParse(num_1, out numero_1))
					{
						Console.WriteLine("El valor ingresado es invalido");
						num_1 = "";
						Console.Clear();
						continue;
					}
				}
				else
				{
					Console.WriteLine(num_1);
				}
				
				Console.SetCursorPosition(4,4);
				Console.WriteLine("Ingresa el segundo numero");
				Console.Write(" .: ");
				
				if(num_2.Equals(""))
				{
					num_2 = Console.ReadLine();
					
					if(!float.TryParse(num_2, out numero_2))
					{
						num_2 = "";
						Console.Clear();
						continue;
					}
					
					if(numero_2 == 0 && (op == 3 || op == 4))
					{
						Console.SetCursorPosition(4,10);
						Console.WriteLine("No se puede dividir entre 0");
						num_2 = "";
						Console.ReadKey();
						Console.Clear();
						continue;
					}
				}
				
				Console.SetCursorPosition(4,7);
				
				switch(op)
				{
					case 0:
						respuesta = numero_1 + numero_2;
						Console.WriteLine($"{num_1} + {num_2} = {respuesta}");
						break;
					case 1:
						respuesta = numero_1 - numero_2;
						Console.WriteLine($"{num_1} - {num_2} = {respuesta}");
						break;
					case 2:
						respuesta = numero_1 * numero_2;
						Console.WriteLine($"{num_1} * {num_2} = {respuesta}");
						break;
					case 3:
						respuesta = numero_1 / numero_2;
						Console.WriteLine($"{num_1} / {num_2} = {respuesta}");
						break;
					case 4:
						respuesta = numero_1 % numero_2;
						Console.WriteLine($"{num_1} % {num_2} = {respuesta}");
						break;
				}
				
				Console.SetCursorPosition(4,10);
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine("Presione una tecla para continuar...");
				Console.ReadKey();
				Console.Clear();
				condition = false;
			}while(condition);
		}
    }
}