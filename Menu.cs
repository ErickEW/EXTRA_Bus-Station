using System;
using System.Collections.Generic;

namespace Extra_Bus_Station
{
    class Menu
    {
        private const int MAIN_MENU_EXIT_OPTION = 9;

        int busPass = 0;

        string timesTrancited = "";

        Dictionary<char,int> countByChar = new Dictionary<char, int>();

        private List<Autobus> elements = new List<Autobus>();

        List<int> mainMenuOptions = new List<int>(new int[] {1, 2, 3, 4, 5, 9});

        List<char> route = new List<char>(new char[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I'});

        private void DisplayWelcomeMenssage()
        {
            System.Console.WriteLine("¡Bienvenido a estaciones Wong! ¿Qué deseas hacer?");
            System.Console.WriteLine();
        }

        private void DisplayMainMenuOptions()
        {
            System.Console.WriteLine("1.- Ingreso de camión");
            System.Console.WriteLine("2.- Salida de camión");
            System.Console.WriteLine("3.- Exportar camiones");
            System.Console.WriteLine("4.- Ver estadísticas");
            System.Console.WriteLine();
            System.Console.WriteLine("9.- Salir");
        }

        private void DisplayByeMessage() 
        {
            System.Console.WriteLine("Hasta luego");
        }

        private int RequestOptions(List<int> validOptions)
        {
            int userInputASInt = 0;
            bool isUserInputValid = false;

            while(!isUserInputValid)
            {
                System.Console.WriteLine("Selecciona una opción");
                string userInput = System.Console.ReadLine();

                try
                {
                    userInputASInt = Convert.ToInt32(userInput);
                    isUserInputValid = validOptions.Contains(userInputASInt);
                }

                catch (SystemException) 
                {
                    isUserInputValid = false;
                }

                if (!isUserInputValid)
                {
                    System.Console.WriteLine("Opción invalida");
                }

            }
            
            return userInputASInt;
        }

        private char validRoute(List<char> validOtp)
        {
            char userInputASChar = ' ';
            bool isUserInputValid = false;

            while (!isUserInputValid)
          {
                System.Console.WriteLine("Inserte una ruta (De la A a la I)");
                string selection = System.Console.ReadLine();

                 try
               {
                userInputASChar = Convert.ToChar(selection);
                isUserInputValid = validOtp.Contains(userInputASChar);
               }
                catch 
            {
                isUserInputValid = false;
            }

            if (!isUserInputValid)
            {
                System.Console.WriteLine("Ruta inexistente");
            }
          }

          timesTrancited = timesTrancited + userInputASChar;
          return userInputASChar;
        }
        
        public void busEntrance()
        {
            System.Console.WriteLine("Inserte el nombre del conductor");
            string depositName = Convert.ToString(Console.ReadLine());
            
            foreach (var caracter in depositName)
            {
             if (caracter == ' ')
             {
                 System.Console.WriteLine("Solo nombre porfavor");
                 return;
             }
            }

            char depositRoute = validRoute(route);

            elements.Add(new Autobus(depositName, depositRoute));
            busPass = busPass + 1;
            System.Console.WriteLine($"Usted seleccionó {depositName} a cargo de la ruta {depositRoute}\n");
        }

        public void busExit()
        {
             if (elements.Count <= 0)
            {
                System.Console.WriteLine("No hay camiones registrados para salir");
            }

            else
            {
                System.Console.WriteLine($"Ha salido {elements[0].Name()} a cargo de la ruta {elements[0].Route()}\n");
                elements.RemoveAt(0);
            }
        }

        public void Export()
        {
             if (elements.Count <= 0)
            {
                System.Console.WriteLine("No hay Autobuses en la estación");
            }
            else
            {
                System.Console.WriteLine("Autobuses dentro de la estación:\n");
                for (int i = elements.Count - 1; i >= 0; i--)
                {

                    System.Console.WriteLine($"Autobus #{i + 1}: {elements[i].Name()} por la ruta {elements[i].Route()}\n");
                }
            }
        }

        public void Stats()
        {
            System.Console.WriteLine($"Ingreso de autobuses = {busPass}");

            foreach (var caracter in timesTrancited)
            {
                if (countByChar.ContainsKey(caracter))
                {
                    countByChar.TryGetValue(caracter, out int currentCount);
                    
                    int nextCount = currentCount;

                    countByChar.Remove(caracter);
                    countByChar.Add(caracter, nextCount);
                }

                else
                {
                    countByChar.Add(caracter, 1);
                }
            }

            System.Console.WriteLine("Veces trancitada =");
            foreach (var item in countByChar)
            {
                System.Console.WriteLine($"{item.Key} -> {item.Value}");
            }

            foreach (var items in countByChar.Keys)
            {
                countByChar.Remove(items);
            }
        }

        public void Display()
        {
            int selectedOption = 0;

            DisplayWelcomeMenssage();

            while (selectedOption != MAIN_MENU_EXIT_OPTION)
            {
                DisplayMainMenuOptions();

                selectedOption = RequestOptions(mainMenuOptions);

                switch (selectedOption)
                {
                  case 1:
                  busEntrance();
                  break;

                  case 2:
                  busExit();
                  break;
     
                  case 3:
                  Export();
                  break;

                  case 4:
                  Stats();
                  break;


                }
            }
            DisplayByeMessage();
        }
    }
}