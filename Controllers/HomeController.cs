using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Propotipo_Index_y_Carrera.Models;
using System.Diagnostics;

namespace Propotipo_Index_y_Carrera.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BD_Prototipo_index_y_carrera;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        // guardo lo necesario para conectar a la base de datos en un string para despues pegar el string y listo
       // List<Preguntasmodel> list = new List<Preguntasmodel>();
        List<Pregunta> list1 = new List<Pregunta>();
        List<CarrerayPregunta> listaIndex=new List<CarrerayPregunta>();
//        List<Carrera> list2 = new List<Carrera>();
        //List<CarrerayPregunta> list3 = new List<CarrerayPregunta>();
        //List<CarreraIma> listima = new List<CarreraIma>();

        /*
         * select Nombre, Descripcion from Carreras
            Union all
           select Pregunta, Respuesta from Preguntas
         */

        //lisrta para guardar los resultados del select

        public IActionResult Index()
        {
            try
            {
                //prepara la conectar
                SqlConnection connection = new SqlConnection(connectionString);
                //abre la coencta
                connection.Open();

                //Pregunta PregADOs;
                //Preguntasmodel PregADO2s;
                // guarda en un string el codigo sql a ejecutar
                //string queryString = "Select * from Carrera";
                /*
                string queryString1 = "Select count(*) from Preguntas";
                //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                // no me acurdo, creoq ue guarda en un comadno sql lo que debe ejecutar y en que conexion hacerlo
                SqlCommand command1 = new SqlCommand(queryString1, connection);
                //  command.ExecuteReader(queryString);
                //command.Parameters.AddWithValue("@Id", id);
                //ejecuta el codigo sql y guarda en reader
                SqlDataReader reader1 = command1.ExecuteReader();
                 int cont_pre=0;
                while (reader1.Read())
                {
                    cont_pre = int.Parse(reader1[0].ToString());
                }
                */

                

         //       string queryString = "Select * from Preguntas";
                //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                // no me acurdo, creoq ue guarda en un comadno sql lo que debe ejecutar y en que conexion hacerlo
          //      SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                //command.Parameters.AddWithValue("@Id", id);
                //ejecuta el codigo sql y guarda en reader
         //       SqlDataReader reader = command.ExecuteReader();

                //repite las filas obtenidas
              //  Pregunta PregADOs;
               // Preguntasmodel PregADO2s;
                
                /*
                string queryString2 = "Select count(*) from Carreras";
                //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                // no me acurdo, creoq ue guarda en un comadno sql lo que debe ejecutar y en que conexion hacerlo
                SqlCommand command2 = new SqlCommand(queryString2, connection);
                //  command.ExecuteReader(queryString);
                //command.Parameters.AddWithValue("@Id", id);
                //ejecuta el codigo sql y guarda en reader
                SqlDataReader reader2 = command2.ExecuteReader();
                int cont_car = 0;
                while (reader2.Read())
                {
                    cont_car = int.Parse(reader2[0].ToString());
                }

                */

                string queryString = "select Id, Nombre, Descripcion, Categoria from Carreras where Categoria='Carrera' Union all select Id ,Pregunta, Respuesta, Categoria from Preguntas where Categoria='Pregunta'";
                //string queryString = "select c.Nombre, c.Descripcion, c.Categoria, c.Imagen, p.Pregunta, p.Respuesta, p.Categoria from Carreras c, Preguntas p where c.Categoria = 'Carrera' and p.Categoria = 'Pregunta'";
                // no me acurdo, creoq ue guarda en un comadno sql lo que debe ejecutar y en que conexion hacerlo
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                //command.Parameters.AddWithValue("@Id", id);
                //ejecuta el codigo sql y guarda en reader
                SqlDataReader reader = command.ExecuteReader();

               // Carrera PregADO1s;
                //CarrerayPregunta indexhome;
                int cont = 0;
                while (reader.Read()) 
                //for (int i = 0; i <= 8; i++)
                {
                    
                    CarrerayPregunta indexhome = new CarrerayPregunta()
                    {
                        Id =int.Parse( reader[0].ToString()),
                        nombre = reader[1].ToString(),
                        Descripcion = reader[2].ToString(),
                        categoria = reader[3].ToString(),

                    };
/*
                    CarrerayPregunta indexhome1 = new CarrerayPregunta()
                    {
                        nombre = reader[0].ToString(),
                        Descripcion = reader[1].ToString(),
                        categoria = reader[2].ToString(),
                        imagen = reader[3].ToString(),
                        pregunta = reader[4].ToString(),
                        respuesta = reader[5].ToString(),
                        categoriap = reader[6].ToString(),

                    };
*/
                    listaIndex.Add(indexhome);
                    
                    
                    /*
                    PregADO2s = new Preguntasmodel()
                    {
                       Preguntaslist = { Id_Pregunta = int.Parse(reader3[0].ToString()),
                            Pregunt = reader3[1].ToString(),
                            //
                            //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                            Respuesta = reader3[2].ToString(),
                            //Imagen = "https://drive.google.com/uc?export=view&id=" + reader[3].ToString(),
                            //Imagen = reader[3].ToString()} ,
                        },
                        

                        Carreraslist = { Id_carrera = int.Parse(reader3[3].ToString()),
                        nombre = reader3[4].ToString(),
                        //
                        //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                        Description = reader3[5].ToString(),
                        Duracion = int.Parse(reader3[6].ToString()),
                        Titulo = reader3[7].ToString(),
                        Incumbencias = reader3[8].ToString(),
                        Imagen = reader3[9].ToString(),},

                    };
                    list.Add(PregADO2s);
                    
                    */
                    /*
                    Pregunta PregADOs = new Pregunta()
                    {


                        //guarda por elemento del modelo carrera
                        Id_Pregunta = int.Parse(reader[0].ToString()),
                        Pregunt = reader[1].ToString(),
                        //
                        //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                        Respuesta = reader[2].ToString(),
                        //Imagen = "https://drive.google.com/uc?export=view&id=" + reader[3].ToString(),
                        //Imagen = reader[3].ToString()

                        pregunta_categoria = reader[3].ToString() 

                        //  Price = int.Parse(reader[4].ToString()),


                        //  Price = int.Parse(reader[4].ToString()),
                    };
                    list1.Add(PregADOs);

                    */
                    /*

                     PregADO1s = new Carrera()
                    {
                        //guarda por elemento del modelo carrera
                        Id_carrera = int.Parse(reader3[0].ToString()),
                        nombre = reader3[1].ToString(),
                        //
                        //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                        Description = reader3[2].ToString(),
                        Duracion = int.Parse(reader3[3].ToString()),
                        Titulo = reader3[4].ToString(),
                        Incumbencias = reader3[5].ToString(),
                        Imagen = reader3[6].ToString(),



                        //Imagen = "https://drive.google.com/uc?export=view&id=" + reader[3].ToString(),
                        //Imagen = reader[3].ToString()

                        //  Price = int.Parse(reader[4].ToString()),
                    };

                    list2.Add(PregADO1s);

                    PregADO2s = new Preguntasmodel()
                    {
                        //guarda por elemento del modelo carrera

                        Carreraslist = PregADO1s,
                        Preguntaslist = PregADOs,
                        




                        //Imagen = "https://drive.google.com/uc?export=view&id=" + reader[3].ToString(),
                        //Imagen = reader[3].ToString()

                        //  Price = int.Parse(reader[4].ToString()),
                    };
                    list.Add(PregADO2s);

                    cont =cont+1;
                    */
                }

               

                /*
                while (reader.Read())
                {
                    //String nameimagen = reader[3].ToString();

                    // nameimagen = nameimagen.Replace("https://drive.google.com/file/d/", "/view?usp=sharing");
                    //  nameimagen = "https://drive.google.com/uc?export=view&id=" + nameimagen;
                     PregADOs = new Pregunta()
                    {


                        //guarda por elemento del modelo carrera
                        Id_Pregunta = int.Parse(reader[0].ToString()),
                        Pregunt = reader[1].ToString(),
                        //
                        //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                        Respuesta = reader[2].ToString(),
                        //Imagen = "https://drive.google.com/uc?export=view&id=" + reader[3].ToString(),
                        //Imagen = reader[3].ToString()
                        


                        //  Price = int.Parse(reader[4].ToString()),


                        //  Price = int.Parse(reader[4].ToString()),
                    };
                    list1.Add(PregADOs);

                
                
                    Carrera PregADO1s = new Carrera()
                    {
                        //guarda por elemento del modelo carrera
                        Id_carrera = int.Parse(reader[3].ToString()),
                        nombre = reader[4].ToString(),
                        //
                        //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                        Description = reader[5].ToString(),
                        Duracion = int.Parse(reader[6].ToString()),
                        Titulo = reader[7].ToString(),
                        Incumbencias = reader[8].ToString(),
                        Imagen = reader[9].ToString(),



                        //Imagen = "https://drive.google.com/uc?export=view&id=" + reader[3].ToString(),
                        //Imagen = reader[3].ToString()

                        //  Price = int.Parse(reader[4].ToString()),
                    };

                    list2.Add(PregADO1s);
                    
                      PregADO2s = new Preguntasmodel()
                     {
                         //guarda por elemento del modelo carrera

                         Carreraslist =PregADO1s ,
                         Preguntaslist = PregADOs,




                         //Imagen = "https://drive.google.com/uc?export=view&id=" + reader[3].ToString(),
                         //Imagen = reader[3].ToString()

                         //  Price = int.Parse(reader[4].ToString()),
                     };
                     list.Add(PregADO2s);
                    
                    //guarda en la lista


                    //list.Add(list1);
                    //  list.Add(movieADOs);
                    // return View(movieADOs);

                    //  list.Add(movieADOs);
                    //list.Add(movieADOs1);
                }
                */

                //cierrra la conexion
                connection.Close();
                //muestra la lista de resutltado
                return View(listaIndex);

            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}