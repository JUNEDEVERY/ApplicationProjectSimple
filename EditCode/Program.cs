/// убраны неиспользуемые библиотеки

namespace ApplicationProjectSimple /// изменено название решения
{
    class Programm
    {
        public static void GenerateModel(int[,] numberOfResources, int[] targetFunction, int[] reserveResource)
        {
            Console.WriteLine("Для вас представлена математическая модель\n");
            Console.Write("F = "); //Формирование целевой функции из введенных данных
            for (int i = 0; i < targetFunction.Length; i++)
            {
                Console.Write($"{targetFunction[i]}x{i + 1} ");
                if (i != targetFunction.Length - 1) // i - индекса x.
                                                    // если индекса икса не равен длине введенных коэффициентов функции, в которой вычли -1
                                                    // условно говоря, осуществляется проверка на последний х
                                                    // если икс последний ставим ему +макс
                {
                    Console.Write("+ ");
                }
                else
                {
                    Console.Write("-> max");
                }

            }
            Console.WriteLine();
            for (int i = 0; i < numberOfResources.GetLength(0); i++) // 0 строки
            {
                for (int j = 0; j < numberOfResources.GetLength(1); j++) // 1 - столбцы
                {

                    Console.Write($"{numberOfResources[i, j]}x{j + 1} "); // т.к индекс массива с нуля. мы ставим +1 для того чтобы в уравнении начинать не с х0, а с х1

                    if (j != numberOfResources.GetLength(1) - 1) // j - индекс икса помощь от андрея с обьясниненим в painte
                                                                 // аналогичная проверка, что и выше. если индекс последнего икса не будет равен количеству ресурсов на ед. продукции, у которой вычли -1, ставим +
                                                                 // условно говоря, если икс не последний, то плюс иначе <=
                    {
                        Console.Write("+ ");

                    }
                    else
                    {
                        Console.WriteLine($"<= {reserveResource[i]}");

                    }

                }

            }
            for (int i = 0; i < targetFunction.Length; i++) // цикл который идет до длины целевой функции, от которой вычли -1.
                                                            // т.к если мы не вычтем -1, то он продолжит ставить индексы к иксу. т.к у нас всего х1 и х2, нам необходимо поставить -1, дабы он не начал ставить х3.
            {
                Console.Write($"x{i + 1}"); // вывод строки с граничными условиями
                /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                if (i != targetFunction.Length - 1)
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.Write(" >=0; ");
                }
            }
        }

        public static void GenerateModelWithoutProm(int[,] numberOfResources, int[] targetFunction, int[] reserveResource)
        {
            Console.WriteLine("Для вас представлена математическая модель\n");
            Console.Write("F = "); //Формирование целевой функции из введенных данных
            for (int i = 0; i < targetFunction.Length; i++)
            {
                Console.Write($"{targetFunction[i]}x{i + 1} ");
                /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                if (i != targetFunction.Length - 1) // i - индекса x.
                                                    // если индекса икса не равен длине введенных коэффициентов функции, в которой вычли -1
                                                    // условно говоря, осуществляется проверка на последний х
                                                    // если икс последний ставим ему +макс
                {
                    Console.Write("+ ");
                }
                else
                {
                    Console.Write("-> max");
                }

            }
            Console.WriteLine();
            for (int i = 0; i < numberOfResources.GetLength(0); i++) // 0 строки
            {
                for (int j = 0; j < numberOfResources.GetLength(1); j++) // 1 - столбцы
                {

                    Console.Write($"{numberOfResources[i, j]}x{j + 1} "); // т.к индекс массива с нуля. мы ставим +1 для того чтобы в уравнении начинать не с х0, а с х1
                    /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                    if (j != numberOfResources.GetLength(1) - 1) 
                    {
                        Console.Write("+ ");

                    }
                    else
                    {
                        Console.WriteLine($"<= {reserveResource[i]}");

                    }
                }
            }
            for (int i = 0; i < targetFunction.Length; i++) // цикл который идет до длины целевой функции, от которой вычли -1.
            {
                Console.Write($"x{i + 1}"); // вывод строки с граничными условиями
                /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                if (i != targetFunction.Length - 1)
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.Write(" >=0; ");
                }
            }

            Console.Write("\n\nF` = -(");
            for (int i = 0; i < targetFunction.Length; i++)
            {
                Console.Write($"{targetFunction[i]}x{i + 1}");
                /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                if (i != targetFunction.Length - 1) // i - индекса x
                                                    // аналогичная проверка что и выше
                {
                    Console.Write(" + ");
                }
                else
                {
                    Console.Write(") -> min");
                }

            }
            Console.WriteLine();
            /// изменено название переменной 
            int dummyVariable = numberOfResources.GetLength(1) + 1; // индекс фиктивной переменной с количеством столбцов
            for (int i = 0; i < numberOfResources.GetLength(0); i++)
            {
                for (int j = 0; j < numberOfResources.GetLength(1); j++)
                {
                    Console.Write($"{numberOfResources[i, j]}x{j + 1}");
                    /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                    if (j != numberOfResources.GetLength(1) - 1) // j - индекс икса
                    {
                        Console.Write(" + ");
                    }
                    else
                    {
                        Console.WriteLine($" + x{dummyVariable} = {reserveResource[i]}");
                        // для того, чтобы в каждой строке прибавлялся индекс фиктивной переменной +1
                        dummyVariable = 1 + dummyVariable; // тоже попросить андрея в paint

                    }
                }
            }
            for (int i = 0; i <= targetFunction.Length - 1; i++) // аналогичный цикл с условием выше
            {
                Console.Write($"x{i + 1}"); // вывод строки с граничными условиями
                /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                if (i != targetFunction.Length - 1)
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.Write(" >=0; ");
                }
            }

            for (int i = numberOfResources.GetLength(1) + 1; i < reserveResource.Length + numberOfResources.GetLength(1) + 1; i++)
            // т.к у нас всего х1 и х2, нам необходимо начать цикл со следующего - т.е х3
            //цикл продолжаем до последнего х
            {
                Console.Write($"x{i}"); // вывод строки с граничными условиями
                /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                if (i != reserveResource.Length + numberOfResources.GetLength(1))
                {
                    Console.Write(", ");

                }
                else
                {
                    Console.Write(" - любое");
                }
            }
            // Этап формирования таблицы
            Console.WriteLine();
            double[,] table1 = new double[reserveResource.Length + 1, numberOfResources.GetLength(1) + numberOfResources.GetLength(0) + 1];
            // количество строк зависит от запаса ( видов ресурсов) +1 для получения строки оценок
            // kolresnaedproduc.GetLength(1) - первый 2 столбца зависят от количества видов продукции (p1 и p2)
            // kolresnaedproduc.GetLength(0) - следующие три столбца для фиктивных переменных. они формируются от количества видов ресурсов
            // сколько строк столько и столбцов с фиктивными переменными
            // +1 добавление столбца запаса ресурсов

            for (int i = 0; i < numberOfResources.GetLength(0); i++)
            {

                for (int j = 0; j < numberOfResources.GetLength(1); j++)
                {
                    table1[i, j] = numberOfResources[i, j];
                    // приравниваем значения первых двух столбцов

                }


            }
            for (int i = 0; i < targetFunction.Length; i++) // заполнение строки оценок
            {
                table1[table1.GetLength(0) - 1, i] = targetFunction[i];

                //
            }

            for (int i = 0; i < reserveResource.Length; i++)
            {



                table1[i, table1.GetLength(1) - 1] = reserveResource[i];

            }
            for (int i = 0; i < table1.GetLength(0) - 1; i++)
            {
                // цикл по i берет все кроме последней строки оценок
                for (int j = numberOfResources.GetLength(1); j < numberOfResources.GetLength(0) * 2 - 1; j++)
                {
                    if (i == j - numberOfResources.GetLength(1)) table1[i, j] = 1;

                }
                // цикл по j

            }
            Console.WriteLine();
            for (int i = 0; i < table1.GetLength(0); i++)
            {

                for (int j = 0; j < table1.GetLength(1); j++)
                {
                    Console.Write(table1[i, j] + " ");


                }
                Console.WriteLine();
            }
        }

        public static void GenerateModelwithStable(int[,] numberOfResources, int[] targetFunction, int[] reserveResource)
        {
            Console.WriteLine("Для вас представлена математическая модель\n");
            Console.Write("F = "); //Формирование целевой функции из введенных данных
            for (int i = 0; i < targetFunction.Length; i++)
            {
                Console.Write($"{targetFunction[i]}x{i + 1} ");
                if (i != targetFunction.Length - 1) // i - индекса x.
                                                    // если индекса икса не равен длине введенных коэффициентов функции, в которой вычли -1
                                                    // условно говоря, осуществляется проверка на последний х
                                                    // если икс последний ставим ему +макс
                {
                    Console.Write("+ ");
                }
                else
                {
                    Console.Write("-> max");
                }

            }
            Console.WriteLine();
            for (int i = 0; i < numberOfResources.GetLength(0); i++) // 0 строки
            {
                for (int j = 0; j < numberOfResources.GetLength(1); j++) // 1 - столбцы
                {

                    Console.Write($"{numberOfResources[i, j]}x{j + 1} "); // т.к индекс массива с нуля. мы ставим +1 для того чтобы в уравнении начинать не с х0, а с х1
                    /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                    if (j != numberOfResources.GetLength(1) - 1) // j - индекс икса помощь от андрея с обьясниненим в painte                                              
                    {
                        Console.Write("+ ");
                    }
                    /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                    else
                    {
                        Console.WriteLine($"<= {reserveResource[i]}");
                    }
                }

            }
            for (int i = 0; i < targetFunction.Length; i++) // цикл который идет до длины целевой функции, от которой вычли -1.
                                                            // т.к если мы не вычтем -1, то он продолжит ставить индексы к иксу. т.к у нас всего х1 и х2, нам необходимо поставить -1, дабы он не начал ставить х3.
            {
                Console.Write($"x{i + 1}"); // вывод строки с граничными условиями
                /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                if (i != targetFunction.Length - 1)
                {
                    Console.Write(", ");
                }
                /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                else
                {
                    Console.Write(" >=0; ");
                }

            }

            Console.Write("\n\nF` = -(");
            for (int i = 0; i < targetFunction.Length; i++)
            {
                Console.Write($"{targetFunction[i]}x{i + 1}");
                /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                if (i != targetFunction.Length - 1) // i - индекса x
                                                    // аналогичная проверка что и выше
                {
                    Console.Write(" + ");
                }
                /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                else
                {
                    Console.Write(") -> min");
                }

            }
            Console.WriteLine();
            /// изменено название перменной
            int dummyVariable = numberOfResources.GetLength(1) + 1; // индекс фиктивной переменной с количеством столбцов
            for (int i = 0; i < numberOfResources.GetLength(0); i++)
            {
                for (int j = 0; j < numberOfResources.GetLength(1); j++)
                {
                    Console.Write($"{numberOfResources[i, j]}x{j + 1}");
                    /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                    if (j != numberOfResources.GetLength(1) - 1) // j - индекс икса
                    {
                        Console.Write(" + ");
                    }
                    /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                    else
                    {
                        Console.WriteLine($" + x{dummyVariable} = {reserveResource[i]}");
                        // для того, чтобы в каждой строке прибавлялся индекс фиктивной переменной +1
                        dummyVariable = 1 + dummyVariable; // тоже попросить андрея в paint
                    }
                }
            }
            for (int i = 0; i <= targetFunction.Length - 1; i++) // аналогичный цикл с условием выше
            {
                Console.Write($"x{i + 1}"); // вывод строки с граничными условиями
                /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                if (i != targetFunction.Length - 1)
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.Write(" >=0; ");
                }
            }
            for (int i = numberOfResources.GetLength(1) + 1; i < reserveResource.Length + numberOfResources.GetLength(1) + 1; i++)
            // т.к у нас всего х1 и х2, нам необходимо начать цикл со следующего - т.е х3
            //цикл продолжаем до последнего х

            {
                Console.Write($"x{i}"); // вывод строки с граничными условиями
                /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                if (i != reserveResource.Length + numberOfResources.GetLength(1))
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.Write(" - любое");
                }
            }
            // Этап формирования таблицы
            Console.WriteLine();
            double[,] table1 = new double[reserveResource.Length + 1, numberOfResources.GetLength(1) + numberOfResources.GetLength(0) + 1];
            // количество строк зависит от запаса ( видов ресурсов) +1 для получения строки оценок
            // kolresnaedproduc.GetLength(1) - первый 2 столбца зависят от количества видов продукции (p1 и p2)
            // kolresnaedproduc.GetLength(0) - следующие три столбца для фиктивных переменных. они формируются от количества видов ресурсов
            // сколько строк столько и столбцов с фиктивными переменными
            // +1 добавление столбца запаса ресурсов

            for (int i = 0; i < numberOfResources.GetLength(0); i++)
            {
                for (int j = 0; j < numberOfResources.GetLength(1); j++)
                {
                    table1[i, j] = numberOfResources[i, j];
                    // приравниваем значения первых двух столбцов
                }
            }
            for (int i = 0; i < targetFunction.Length; i++) // заполнение строки оценок
            {
                table1[table1.GetLength(0) - 1, i] = targetFunction[i];
            }

            for (int i = 0; i < reserveResource.Length; i++)
            {
                table1[i, table1.GetLength(1) - 1] = reserveResource[i];
            }
            for (int i = 0; i < table1.GetLength(0) - 1; i++)
            {
                // цикл по i берет все кроме последней строки оценок
                for (int j = numberOfResources.GetLength(1); j < numberOfResources.GetLength(0) * 2 - 1; j++)
                {
                    if (i == j - numberOfResources.GetLength(1)) table1[i, j] = 1;
                }
            }
            Console.WriteLine();
            for (int i = 0; i < table1.GetLength(0); i++)
            {
                for (int j = 0; j < table1.GetLength(1); j++)
                {
                    Console.Write(table1[i, j] + " ");
                }
                Console.WriteLine();
            }
            // Вывод промежуточных результатов
            Console.WriteLine("\nПромежуточные результаты");
            Console.WriteLine($"F`={table1[table1.GetLength(0) - 1, table1.GetLength(1) - 1]}");
            Console.WriteLine($"F={Math.Abs(table1[table1.GetLength(0) - 1, table1.GetLength(1) - 1])}");
            for (int d = 0; d < targetFunction.Length; d++)
            {
                Console.WriteLine($"x{d + 1} = 0");
            }
            for (int i = 0; i < numberOfResources.GetLength(0); i++)
            {
                Console.WriteLine($"x{numberOfResources.GetLength(1) + 1 + i} = {reserveResource[i]} ");
            }

        }

        static void Main(string[] args)
        {
            try /// добавлен блой try catch для обработки исключений
            {
                Console.WriteLine("\t\t\t\t\t\tЗдравствуйте!");
                Console.WriteLine("\t\t\tДля вас была разработана обучающая программа по теме");
                Console.WriteLine("\t\t\tПостроение канонической задачи минимазации (КЗМ) и результатов первой симплекс-таблицы");
                Console.WriteLine("\t\tПрограмма, помимо решения определенной задачи, также содержит тестирование, в котором Вы можете проверить свои знания");
                Console.WriteLine("\t\t\t\tТяжело в учении, легко в бою! Желаем удачи!");
                Console.WriteLine("\t\t\t\tНажмите любую клавишу для перехода в меню");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("1 - Решение задачи по построению канонической задачи минимизации и результатов первой симплекс-таблицы");
                Console.WriteLine("2 - Проверить себя");
                /// изменено название переменной
                int changeVariable = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (changeVariable)
                {
                    case 1: /// убран закомментированый участок кода, который не используется
                            /// изменены названия трех переменных. выдал друго тип массиву. double кушает больше ОЗУ
                        int[,] numberOfResources = new int[,] { { 6, 6 }, { 4, 2 }, { 4, 8 } }; // двумерный массив для хранения двух столбцов. она же - матрица
                        int[] targetFunction = new int[] { 12, 15 }; // одномерный массив для хранения данных целевой функции
                        int[] stockOfProducts = new int[] { 36, 20, 40 }; // одномерный массив для храненый данных о запасе ресурсов
                        Console.Write("F = "); // Формирование целевой функции из введенных данных
                        for (int i = 0; i < targetFunction.Length; i++)
                        {
                            Console.Write($"{targetFunction[i]}x{i + 1} ");
                            if (i != targetFunction.Length - 1) // i - индекса x.
                                                                // если индекса икса не равен длине введенных коэффициентов функции, в которой вычли -1
                                                                // условно говоря, осуществляется проверка на последний х
                                                                // если икс последний ставим ему +макс
                            {
                                Console.Write("+ ");
                            }
                            else
                            {
                                Console.Write("-> max");
                            }
                        }
                        Console.WriteLine();
                        for (int i = 0; i < numberOfResources.GetLength(0); i++) // 0 строки
                        {
                            for (int j = 0; j < numberOfResources.GetLength(1); j++) // 1 - столбцы
                            {
                                Console.Write($"{numberOfResources[i, j]}x{j + 1} "); // т.к индекс массива с нуля. мы ставим +1 для того чтобы в уравнении начинать не с х0, а с х1

                                if (j != numberOfResources.GetLength(1) - 1) // j - индекс икса помощь от андрея с обьясниненим в painte                                           
                                {
                                    Console.Write("+ ");
                                }
                                else
                                {
                                    Console.WriteLine($"<= {stockOfProducts[i]}");

                                }
                            }
                        }
                        for (int i = 0; i < targetFunction.Length; i++) // цикл который идет до длины целевой функции, от которой вычли -1.

                        {
                            Console.Write($"x{i + 1}"); // вывод строки с граничными условиями
                            if (i != targetFunction.Length - 1)
                            {
                                Console.Write(", ");
                            }
                            else Console.Write(" >=0; ");
                            // цикл без i <= function.Length -1 позволяет добавлять х1,х2 и х3 взависимости от того, сколько указано значений в переменной function(целевая функция)
                            //Console.Write($"x{i + 1} >= 0 "); // вывод строки с граничными условиями
                        }
                        // Построение канонической задачи минимизации
                        Console.Write("\n\nF` = -(");
                        for (int i = 0; i < targetFunction.Length; i++)
                        {
                            Console.Write($"{targetFunction[i]}x{i + 1}");
                            if (i != targetFunction.Length - 1) // i - индекса x
                                                                // аналогичная проверка что и выше
                            {
                                Console.Write(" + ");
                            }
                            else
                            {
                                Console.Write(") -> min");
                            }

                        }
                        Console.WriteLine();
                        /// измненено название переменной
                        int dummyVariable = numberOfResources.GetLength(1) + 1; // индекс фиктивной переменной с количеством столбцов
                                                                                // для создания фиктивной переменной нам необходимо получить индекс последней переменной и к ней прибавить +1
                        for (int i = 0; i < numberOfResources.GetLength(0); i++)
                        {
                            for (int j = 0; j < numberOfResources.GetLength(1); j++)
                            {
                                Console.Write($"{numberOfResources[i, j]}x{j + 1}");
                                /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                                if (j != numberOfResources.GetLength(1) - 1) // j - индекс икса
                                {
                                    Console.Write(" + ");
                                }
                                /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                                else
                                {
                                    Console.WriteLine($" + x{dummyVariable} = {stockOfProducts[i]}");
                                    // для того, чтобы в каждой строке прибавлялся индекс фиктивной переменной +1
                                    dummyVariable = 1 + dummyVariable;
                                }
                            }

                        }
                        for (int i = 0; i <= targetFunction.Length - 1; i++) // аналогичный цикл с условием выше
                        {
                            /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                            Console.Write($"x{i + 1}"); // вывод строки с граничными условиями
                            if (i != targetFunction.Length - 1)
                            {
                                Console.Write(", ");
                            }
                            else
                            {
                                Console.Write(" >=0; ");
                            }
                        }

                        for (int i = numberOfResources.GetLength(1) + 1; i < stockOfProducts.Length + numberOfResources.GetLength(1) + 1; i++)
                        // т.к у нас всего х1 и х2, нам необходимо начать цикл со следующего - т.е х3
                        //цикл продолжаем до последнего х
                        {
                            Console.Write($"x{i}"); // вывод строки с граничными условиями
                            /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                            if (i != stockOfProducts.Length + numberOfResources.GetLength(1))
                            {
                                Console.Write(", ");
                            }
                            else
                            {
                                Console.Write(" - любое");
                            }

                        }
                        // Этап формирования таблицы
                        Console.WriteLine();
                        double[,] table = new double[stockOfProducts.Length + 1, numberOfResources.GetLength(1) + numberOfResources.GetLength(0) + 1];
                        // количество строк зависит от запаса ( видов ресурсов) +1 для получения строки оценок
                        for (int i = 0; i < numberOfResources.GetLength(0); i++)
                        {

                            for (int j = 0; j < numberOfResources.GetLength(1); j++)
                            {
                                table[i, j] = numberOfResources[i, j];
                                // приравниваем значения первых двух столбцов
                            }

                        }
                        for (int i = 0; i < targetFunction.Length; i++) // заполнение строки оценок
                        {
                            table[table.GetLength(0) - 1, i] = targetFunction[i];
                        }

                        for (int i = 0; i < stockOfProducts.Length; i++)
                        {

                            table[i, table.GetLength(1) - 1] = stockOfProducts[i];

                        }
                        for (int i = 0; i < table.GetLength(0) - 1; i++)
                        {
                            // цикл по i берет все кроме последней строки оценок
                            for (int j = numberOfResources.GetLength(1); j < numberOfResources.GetLength(0) * 2 - 1; j++)
                            {
                                /// добавлены фигурные скобки (требование использовать конструкию if с фигурными скобками)
                                if (i == j - numberOfResources.GetLength(1))
                                {
                                    table[i, j] = 1;
                                }

                            }
                            // цикл по j

                        }
                        Console.WriteLine();
                        for (int i = 0; i < table.GetLength(0); i++)
                        {

                            for (int j = 0; j < table.GetLength(1); j++)
                            {
                                Console.Write(table[i, j] + " ");

                            }
                            Console.WriteLine();
                        }
                        // Вывод промежуточных результатов
                        Console.WriteLine("\nПромежуточные результаты");
                        Console.WriteLine($"F`={table[table.GetLength(0) - 1, table.GetLength(1) - 1]}");
                        Console.WriteLine($"F={Math.Abs(table[table.GetLength(0) - 1, table.GetLength(1) - 1])}");
                        for (int d = 0; d < targetFunction.Length; d++)
                        {
                            Console.WriteLine($"x{d + 1} = 0");
                        }
                        for (int i = 0; i < numberOfResources.GetLength(0); i++)
                        {
                            Console.WriteLine($"x{numberOfResources.GetLength(1) + 1 + i} = {stockOfProducts[i]} ");
                        }
                        break;

                    case 2:
                        Console.WriteLine("\nБаллы по тестированию выставляются следующим образом");
                        Console.WriteLine("9-10 правильных ответов - оценка отлично");
                        Console.WriteLine("7-8 правильных ответов - оценка хорошо");
                        Console.WriteLine("5-6 правильных ответов - оценка удовлетворительно");
                        Console.WriteLine("0-3 правильных ответов - оценка неудовлетворительно");
                        Console.WriteLine("\nНажмите любую клавишу для продолжения!");
                        Console.ReadKey();
                        Console.Clear();
                        /// Изменено название рандомной переменной
                        Random random = new Random();
                        int x = random.Next(2, 5), firstResponseVariable = random.Next(4, 8);
                        /// Измененены названия переменных и их тип для быстродействия
                        int[,] numberOfResourcesSecond = new int[firstResponseVariable, x]; // двумерный массив для хранения двух столбцов. она же - матрица
                        int[] secondTargetFunction = new int[x]; // одномерный массив для хранения данных целевой функции
                        int[] secondStockProducts = new int[firstResponseVariable]; // одномерный массив для храненый данных о запасе ресурсов
                        for (int i = 0; i < numberOfResourcesSecond.GetLength(0); i++)
                        {
                            for (int j = 0; j < numberOfResourcesSecond.GetLength(1); j++)
                            {
                                numberOfResourcesSecond[i, j] = random.Next(1, 10);
                                secondTargetFunction[j] = random.Next(1, 15);
                            }
                            secondStockProducts[i] = random.Next(20, 50);

                        }
                        /// вербльюжая нотация применена к переменной
                        int answerQuestion = 0;
                        GenerateModel(numberOfResourcesSecond, secondTargetFunction, secondStockProducts);
                        Console.WriteLine("\n Вопрос 1. К чему будет стремится целевая функция в канонической задаче минимизации(КЗМ) ? ");
                        /// изменено название пользовательской переменной
                        string responseUser = Convert.ToString(Console.ReadLine());
                        if (responseUser == "min")
                        {
                            Console.WriteLine("Ответ верный");
                            answerQuestion = answerQuestion + 1;

                        }
                        else
                        {
                            Console.WriteLine("Ответ неверный. Целевая функция стремится к min");
                        }

                        Console.WriteLine("Нажмите любую клавишу для продолжения!");
                        Console.ReadKey();
                        Console.Clear();
                        GenerateModel(numberOfResourcesSecond, secondTargetFunction, secondStockProducts);
                        Console.WriteLine("\n Вопрос 2. Сколько используется видов продукции?");
                        /// изменены название переменной на верб. нотацию
                        int productType = Convert.ToInt32(Console.ReadLine());
                        if (productType == secondTargetFunction.Length)
                        {
                            Console.WriteLine($"Ответ верный! Всего видов продукции {secondTargetFunction.Length}");
                            answerQuestion = answerQuestion + 1;


                        }
                        else
                        {
                            Console.WriteLine($"Ответ неверный Всего видов продукции {secondTargetFunction.Length}");

                        }
                        Console.WriteLine("Нажмите любую клавишу для продолжения!");
                        Console.ReadKey();
                        Console.Clear();
                        GenerateModel(numberOfResourcesSecond, secondTargetFunction, secondStockProducts);
                        Console.WriteLine("\n Вопрос 3.Сколько фиктивных переменных используется в построенной математической модели?");
                        /// изменено название переменной на верб. нотацию
                        int dummyVariableSecond = Convert.ToInt32(Console.ReadLine());
                        if (firstResponseVariable == dummyVariableSecond)
                        {
                            Console.WriteLine("Ответ верный. Всего фиктивных переменных");
                            answerQuestion = answerQuestion + 1;
                            Console.WriteLine("Нажмите любую клавишу для продолжения!");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine($"Ответ не верный, т.к количество фиктивных переменных {firstResponseVariable}");
                            Console.WriteLine("Нажмите любую клавишу для продолжения!");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        GenerateModelWithoutProm(numberOfResourcesSecond, secondTargetFunction, secondStockProducts);
                        Console.WriteLine($"\n Вопрос 4. Чему равно х {numberOfResourcesSecond.GetLength(1) + numberOfResourcesSecond.GetLength(0)}?");
                        /// изменено название переменной на верб. нотацию
                        int secondResponseVariable = Convert.ToInt32(Console.ReadLine());
                        if (secondResponseVariable == secondStockProducts[secondStockProducts.Length - 1])
                        {
                            Console.WriteLine("Ответ верный! ");
                            answerQuestion = answerQuestion + 1;
                        }
                        else
                        {
                            Console.WriteLine("Ответ неверный, т.к ");
                            Console.WriteLine($"X = {secondStockProducts[numberOfResourcesSecond.GetLength(1)]}");
                        }
                        Console.WriteLine("Нажмите любую клавишу для продолжения!");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("\n Вопрос 5.Какой знак ставится в процессе формирования канонической задачи минимизации целевой функции?");
                        /// изменено название переменной на верб. нотацию
                        string thirdResponseVariable = Convert.ToString(Console.ReadLine());
                        if (thirdResponseVariable == "-")
                        {
                            Console.WriteLine("Ответ верный");
                            answerQuestion = answerQuestion + 1;
                        }
                        else
                        {
                            Console.WriteLine("Ответ неверный, т.к в процессе формирования канонической задачи минимизации целевой функции перед коэффициентами ставится знак - (минус)");
                        }
                        Console.WriteLine("Нажмите любую клавишу для продолжения!");
                        Console.ReadKey();
                        Console.Clear();
                        GenerateModelwithStable(numberOfResourcesSecond, secondTargetFunction, secondStockProducts);
                        Console.WriteLine("\n Вопрос 6. Является ли данное решение окончательным?");
                        /// изменено название переменной на верб. нотацию
                        string fourthResponseVariable = Convert.ToString(Console.ReadLine());
                        if ((fourthResponseVariable == "Да") || (fourthResponseVariable == "ДА") || (fourthResponseVariable == "да"))
                        {
                            Console.WriteLine("Ответ неверный");
                            Console.WriteLine("Данное решение не явлется окончательным, т.к формируется математическая модель,КЗМ и первая симплекс таблица");
                        }
                        else if ((fourthResponseVariable == "НЕТ") || (fourthResponseVariable == "Нет") || (fourthResponseVariable == "нет"))
                        {
                            Console.WriteLine("Ответ верный!");
                            answerQuestion = answerQuestion + 1;
                        }
                        Console.WriteLine("Нажмите любую клавишу для продолжения!");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("\n Вопрос 7. Чему равна целевая функция после построения первой симплекс таблицы?");
                        /// изменено название переменной на верб. нотацию
                        string fifthResponseVariable = Convert.ToString(Console.ReadLine());
                        if (fifthResponseVariable == "0")
                        {
                            Console.WriteLine("Ответ верный");
                            answerQuestion = answerQuestion + 1;
                        }
                        else
                        {
                            Console.WriteLine("Ответ неверный!");
                        }
                        Console.WriteLine("Нажмите любую клавишу для продолжения!");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("\n Вопрос 8. Чему равна F` после построения первой симплекс таблицы?");
                        /// изменено название переменной на верб. нотацию
                        string sixthResponseVariable = Convert.ToString(Console.ReadLine());
                        if (sixthResponseVariable == "0")
                        {
                            Console.WriteLine("Ответ верный");
                            answerQuestion = answerQuestion + 1;
                        }
                        else
                        {
                            Console.WriteLine("Ответ неверный!");
                        }
                        Console.WriteLine("Нажмите любую клавишу для продолжения!");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("\n Вопрос 9. Какой знак будут иметь ограничения в КЗМ?");
                        /// изменено название переменной на верб. нотацию
                        string seventhResponseVariable = Convert.ToString(Console.ReadLine());
                        if (seventhResponseVariable == "=")
                        {
                            Console.WriteLine("Ответ верный");
                            answerQuestion = answerQuestion + 1;
                        }
                        else
                        {
                            Console.WriteLine("Ответ неверный!");
                        }
                        Console.WriteLine("Нажмите любую клавишу для продолжения!");
                        Console.ReadKey();
                        Console.Clear();
                        GenerateModelwithStable(numberOfResourcesSecond, secondTargetFunction, secondStockProducts);
                        Console.WriteLine("\n Вопрос 10. Сколько строк и стобцов содержит первая симпекс таблица?");
                        Console.WriteLine("Ответ представить ввиде суммы строк и столбцов (m+n)");
                        /// изменено название переменной на верб. нотацию
                        int eigthResponseVariable = Convert.ToInt32(Console.ReadLine());
                        if (eigthResponseVariable == x + firstResponseVariable + firstResponseVariable + 2)
                        {
                            Console.WriteLine("Ответ верный");
                            answerQuestion = answerQuestion + 1;
                        }
                        else
                        {
                            Console.WriteLine("Ответ неверный!");
                            Console.WriteLine("Сумма строк и столбцов равна = " + x + firstResponseVariable + firstResponseVariable + 2);
                        }
                        Console.WriteLine("Тестирование закончилось.");
                        Console.WriteLine("Загрузка результатов тестирования..");
                        Console.WriteLine("Загрузка результатов тестирования...");
                        Console.WriteLine("Загрузка результатов тестирования.....");


                        Console.WriteLine($"В результате тестирования вы набрали {answerQuestion} баллов из 10");
                        if (answerQuestion >= 9)
                        {
                            Console.WriteLine("Вы получили оценку 5. Вы молодец!");
                        }
                        else if (answerQuestion >= 7)
                        {
                            Console.WriteLine("Вы получили оценку 4. Не плохо!");
                        }
                        else if (answerQuestion >= 5)
                        {
                            Console.WriteLine("Вы получили оценку 3. Могло быть и лучше!");
                        }
                        else if (answerQuestion >= 3)
                        {
                            Console.WriteLine("Вы получили оценку 2. Может быть в другой раз...?");
                        }

                        /// убран неиспользуемый код
                        break;
                }

            }
            catch
            {
                Console.WriteLine("Что-то пошло не так!");
            }
        }
    }
}