using Microsoft.AspNetCore.Mvc;
using Propotipo_Index_y_Carrera.Models;

using System.Diagnostics;

// usibg
using Microsoft.Data.SqlClient;

namespace Propotipo_Index_y_Carrera.Controllers
{
    public class PreguntaController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        
        public PreguntaController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BD_Prototipo_index_y_carrera;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        // guardo lo necesario para conectar a la base de datos en un string para despues pegar el string y listo
        List<Pregunta> list = new List<Pregunta>();
        //List<CarreraIma> listima = new List<CarreraIma>();



        //lisrta para guardar los resultados del select
        public IActionResult Index()
        {
            try
            {
                //prepara la conectar
                SqlConnection connection = new SqlConnection(connectionString);
                //abre la coencta
                connection.Open();
                // guarda en un string el codigo sql a ejecutar
                //string queryString = "Select * from Carrera";
                string queryString = "Select * from Preguntas";
                //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                // no me acurdo, creoq ue guarda en un comadno sql lo que debe ejecutar y en que conexion hacerlo
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                //command.Parameters.AddWithValue("@Id", id);
                //ejecuta el codigo sql y guarda en reader
                SqlDataReader reader = command.ExecuteReader();

                //repite las filas obtenidas
                while (reader.Read())
                {
                    //String nameimagen = reader[3].ToString();

                    // nameimagen = nameimagen.Replace("https://drive.google.com/file/d/", "/view?usp=sharing");
                    //  nameimagen = "https://drive.google.com/uc?export=view&id=" + nameimagen;
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

                        //  Price = int.Parse(reader[4].ToString()),
                    };
                    //guarda en la lista
                    list.Add(PregADOs);
                    //  list.Add(movieADOs);
                    // return View(movieADOs);

                    //  list.Add(movieADOs);
                    //list.Add(movieADOs1);
                }


                //cierrra la conexion
                connection.Close();
                //muestra la lista de resutltado
                return View(list);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pregunta mov)
        //public async Task<IActionResult> Create(CarreraIma mov)
        {
            try
            {

                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                string queryString = "INSERT INTO Preguntas ( Pregunta, Respuesta, Categoria) VALUES ( @Pregunta, @Respuesta, @Categoria);";
                //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                //toma los parametros obtenidos para despues agregarlos en el consulta sql
                command.Parameters.AddWithValue("@pregunta", mov.Pregunt);
                command.Parameters.AddWithValue("@Respuesta", mov.Respuesta);
                command.Parameters.AddWithValue("@Categoria", "Pregunta");


                //string nameimagen = mov.Imagen;
                //   command.Parameters.AddWithValue("@nombreimagen", mov.Imagen);
                //command.Parameters.AddWithValue("@nombreimagen", files);
                //string nameimagen = "https://localhost:7021/images/logo8.jpeg";
                //pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                // nameimagen = Image.FromFile(mov.Imagen);
                //  nameimagen.Load("\\Imagenes\\correcto.png");

                //mov.Imagen.Save("c:\capturador de pantalla\imagen" & ".jpg,");

                // string carpeta= Application.StartupPath + @"/carpeta";

                //  string destino = @"D:\Fotos\" + mov.Name + ".Jpeg";
                //7 nameimagen.Save(destino, ImageFormat.Jpeg);
                //nameimagen = nameimagen.Replace("https://drive.google.com/file/d/" , "");
                //nameimagen = nameimagen.Replace( "/view?usp=sharing", "");
                //nameimagen = nameimagen.Replace("/view?usp=sharing/","");


                //   var filePath = _hostingEnvironment + "\\wwwroot\\" + mov.Name;
                // var filePath = "WaffleWebWorksTpFinal\\wwwroot\\images\\" + mov.Name;

                //  await files.SaveAsAsync(filePath);

                //HttpPostedFileBase
                //   string path = Path.Combine(files.MapPath("~/UploadedFiles"), Path.GetFileName(file.FileName));
                //  files.SaveAs(path);






                //ejecuta la consulta
                SqlDataReader reader = command.ExecuteReader();


                connection.Close();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }


        /* public byte[] ConvertToBytes(HttpPostedFileBase image)
         {
             byte[] imageBytes = null;
             BinaryReader reader = new BinaryReader(image.InputStream);
             imageBytes = reader.ReadBytes((int)image.ContentLength);
             return imageBytes;
         }*/

        public ActionResult Detalle(int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                //filtra por id
                string queryString = "Select * from Preguntas Where Id=@Id";
                //string queryString = "INSERT INTO carrera (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                //necesario hacer este para que sepa a que id filtrar
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Pregunta movieADOs = new    Pregunta()
                    {
                        Id_Pregunta = int.Parse(reader[0].ToString()),
                        Pregunt = reader[1].ToString(),
                        //
                        //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                        Respuesta = reader[2].ToString(),
                        // Imagen = "https://drive.google.com/uc?export=view&id=" + reader[3].ToString(),
                        //Imagen = reader[3].ToString(),
                        pregunta_categoria="Pregunta",
                    };
                    return View(movieADOs);

                    //  list.Add(movieADOs);
                    //list.Add(movieADOs1);
                }



                connection.Close();
                return View();

            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //esto seria editor pero el editor sin httpost es lo mismo que el de arriba. ademas un poco de variedad
        public async Task<IActionResult> Detalle(int id, Pregunta mov)
        {

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string queryString = "update Preguntas   set  pregunta=@pregunta, Respuesta=@Respuesta where Id = @id";
                //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Pregunta", mov.Pregunt);
                command.Parameters.AddWithValue("@Respuesta", mov.Respuesta);

             //   String nameimagen = mov.Imagen;

                // nameimagen = nameimagen.Replace("https://drive.google.com/file/d/", "");
                // nameimagen = nameimagen.Replace("/view?usp=sharing", "");
                //nameimagen = nameimagen.Replace("/view?usp=sharing/","");

//                command.Parameters.AddWithValue("@nombreimagen", nameimagen);




                SqlDataReader reader = command.ExecuteReader();


                connection.Close();

                return RedirectToAction("Detalle");

            }
            catch (Exception)
            {

                throw;
            }


        }
        // intente hacer lo mismo que arriba pero no pude, la razon nose 
        public IActionResult Delete(int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string queryString = "Select * from Preguntas Where Id=@Id";
                //string queryString = "INSERT INTO carrera (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Pregunta movieADOs = new Pregunta()
                    {
                        Id_Pregunta = int.Parse(reader[0].ToString()),
                        Pregunt = reader[1].ToString(),
                        //
                        //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                        Respuesta = reader[2].ToString(),
                     //   Imagen = reader[3].ToString()

                    };
                    return View(movieADOs);

                    //  list.Add(movieADOs);
                    //list.Add(movieADOs1);
                }



                connection.Close();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Pregunta mov)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string queryString = "delete from Preguntas where Id = @Id";
                //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                command.Parameters.AddWithValue("@Id", mov.Id_Pregunta);


                command.ExecuteReader();


                connection.Close();

                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
