namespace ExamenPractico1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            string menuOption, submenuOption;
            int indexSong = 0, indexStudent = 0, maxStudents = 100;

            // arreglos ejercicio 1
            string[] artist = new string[15], title = new string[15];
            int[] duration = new int[15];
            double[] size = new double[15];

            // arreglos ejercicio 2
            int[] studentCode = new int[maxStudents], registerYear = new int[maxStudents];
            string[] fullName = new string[maxStudents], birthDate = new string[maxStudents], grade = new string[maxStudents];

            while (!exit)
            {
                //Menú principal de programa
                Console.WriteLine("------------------- Menú -------------------\n");
                Console.WriteLine("[1] Ejercicio 1: Datos de canción".PadLeft(10));
                Console.WriteLine("[2] Ejercicio 2: Gestión de centro escolar".PadLeft(10));
                Console.WriteLine("[3] Salir\n".PadLeft(10));
                Console.Write("Opción: ");
                menuOption = Console.ReadLine();
                Console.Clear();
                switch (menuOption)
                {
                    case "1":
                        // almacenamiento de canciones en formato mp3
                        if (indexSong >= artist.Length)
                        {
                            Console.WriteLine("Ya no es posible agregar más canciones");
                            Console.Clear();
                            Console.ReadKey();
                            continue;
                        }

                        Console.WriteLine("---- Registro de datos de canción ----\n");
                        Console.Write("Título de la canción: ");
                        title[indexSong] = Console.ReadLine();
                        Console.Write("Nombre del artista: ");
                        artist[indexSong] = Console.ReadLine();
                        Console.Write("Duración de canción (segundos): ");
                        duration[indexSong] = int.Parse(Console.ReadLine());
                        Console.Write("Tamaño del fichero (KB): ");
                        size[indexSong] = double.Parse(Console.ReadLine());
                        Console.Clear();

                        Console.WriteLine("----- Canciones disponibles -----\n");
                        for (int i = 0; i <= indexSong; i++)
                        {
                            Console.WriteLine($"Canción:  {title[i]}.mp3");
                            Console.WriteLine($"Artista:  {artist[i]}");
                            Console.WriteLine($"Duración: {duration[i]} segundos");
                            Console.WriteLine($"Tamaño:   {size[i]}KB\n\n");
                        }
                        indexSong++;
                        break;

                    case "2":
                        // gestión de alumnos
                        bool exitSubmenu = false;
                        while (!exitSubmenu)
                        {
                            Console.WriteLine("----- Menú Gestión de Centro Escolar -----\n");
                            Console.WriteLine("[1] Agregar alumno".PadLeft(10));
                            Console.WriteLine("[2] Mostrar alumnos".PadLeft(10));
                            Console.WriteLine("[3] Buscar alumno por código".PadLeft(10));
                            Console.WriteLine("[4] Editar alumno por código".PadLeft(10));
                            Console.WriteLine("[5] Regresar a menú principal\n".PadLeft(10));

                            Console.Write("Opción: ");
                            submenuOption = Console.ReadLine();
                            Console.Clear();

                            switch (submenuOption)
                            {
                                case "1":
                                    if (indexStudent < maxStudents)
                                    {
                                        addStudent(indexStudent, studentCode, fullName, birthDate, grade, registerYear);
                                        Console.WriteLine("\nAlumno añadido satisfactoriamente");
                                        indexStudent++;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ya no es posible agregar estudiantes");
                                    }
                                    break;

                                case "2":
                                    showStudents(indexStudent, studentCode, fullName, birthDate, grade, registerYear);
                                    break;

                                case "3":
                                    Console.WriteLine("---- Búsqueda de alumno por código ----\n");
                                    int position = searchStudent(studentCode);
                                    Console.WriteLine();
                                    showStudent(position, studentCode, fullName, birthDate, grade, registerYear);
                                    break;

                                case "4":
                                    Console.WriteLine("---- Editar alumno por código ----\n");
                                    editStudent(studentCode, fullName, birthDate, grade, registerYear);
                                    break;

                                case "5":
                                    exitSubmenu = true;
                                    continue;

                                default:
                                    Console.WriteLine("Opción no disponible");
                                    break;
                            }
                            Console.ReadKey();
                            Console.Clear();
                        }
                        continue;

                    case "3":
                        exit = true;
                        continue;

                    default:
                        Console.WriteLine("Opción no disponible");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        // agregar alumno
        static void addStudent(int indexStudent, int[] studentCode, string[] fullName, string[] birthDate, string[] grade, int[] registerYear)
        {
            Console.Write("Código de alumno: ");
            studentCode[indexStudent] = int.Parse(Console.ReadLine());
            Console.Write("Nombre de alumno: ");
            fullName[indexStudent] = Console.ReadLine();
            Console.Write("Fecha de nacimiento (DD/MM/AAAA): ");
            birthDate[indexStudent] = Console.ReadLine();
            Console.Write("Grado actual: ");
            grade[indexStudent] = Console.ReadLine();
            Console.Write("Año de registro: ");
            registerYear[indexStudent] = int.Parse(Console.ReadLine());
        }

        // mostrar listado de alumnos registrados
        static void showStudents(int indexStudent, int[] studentCode, string[] fullName, string[] birthDate, string[] grade, int[] registerYear)
        {
            if (indexStudent == 0)
            {
                Console.WriteLine("No hay alumnos registrados");
                return;
            }

            Console.Write("Código".PadRight(12));
            Console.Write("Nombre Completo".PadRight(21));
            Console.Write("Fecha de Nacimiento".PadRight(25));
            Console.Write("Grado".PadRight(11));
            Console.WriteLine("Año de registro".PadRight(21));
            Console.WriteLine("".PadRight(85, '-'));

            for (int i = 0; i < indexStudent; i++)
            {
                Console.Write($"{studentCode[i]}".PadRight(12));
                Console.Write($"{fullName[i]}".PadRight(21));
                Console.Write($"{birthDate[i]}".PadRight(25));
                Console.Write($"{grade[i]}".PadRight(11));
                Console.WriteLine($"{registerYear[i]}".PadRight(21));
            }
        }

        // mostrar un alumno específico
        static void showStudent(int indexStudent, int[] studentCode, string[] fullName, string[] birthDate, string[] grade, int[] registerYear)
        {
            if (indexStudent == -1)
            {
                Console.WriteLine("No hay alumnos registrados con ese código");
                return;
            }

            Console.Write("Código".PadRight(12));
            Console.Write("Nombre Completo".PadRight(21));
            Console.Write("Fecha de Nacimiento".PadRight(25));
            Console.Write("Grado".PadRight(11));
            Console.WriteLine("Año de registro".PadRight(21));
            Console.WriteLine("".PadRight(85, '-'));

            Console.Write($"{studentCode[indexStudent]}".PadRight(12));
            Console.Write($"{fullName[indexStudent]}".PadRight(21));
            Console.Write($"{birthDate[indexStudent]}".PadRight(25));
            Console.Write($"{grade[indexStudent]}".PadRight(11));
            Console.WriteLine($"{registerYear[indexStudent]}".PadRight(21));
        }

        // buscar alumno por su código
        static int searchStudent(int[] studentCode)
        {
            int position, code;
            Console.Write("Código de alumno: ");
            code = int.Parse(Console.ReadLine());

            foreach (int i in studentCode)
            {
                if (code == studentCode[i])
                {
                    position = i;
                    return position;
                }
            }
            return -1;
        }

        // editar alumno buscado por su código
        static void editStudent(int[] studentCode, string[] fullName, string[] birthDate, string[] grade, int[] registerYear)
        {
            int indexStudent = searchStudent(studentCode);

            if (indexStudent == -1)
            {
                Console.WriteLine("No hay alumnos registrados con ese código");
                return;
            }

            Console.WriteLine($"\nEditando a: {fullName[indexStudent]}");
            addStudent(indexStudent, studentCode, fullName, birthDate, grade, registerYear);
            Console.WriteLine("\nAlumno editado satisfactoriamente");
        }

    }
}