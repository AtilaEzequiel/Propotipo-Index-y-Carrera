using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Propotipo_Index_y_Carrera.Models;

namespace Propotipo_Index_y_Carrera.Controllers
{
    public class IncumbenciaController : Controller
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BD_Prototipo_index_y_carrera;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        // guardo lo necesario para conectar a la base de datos en un string para despues pegar el string y listo
        List<incumbencia> list = new List<incumbencia>();
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
                string queryString = "Select * from Incumbencia";
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
                    incumbencia PregADOs = new incumbencia()
                    {
                        //guarda por elemento del modelo carrera
                        Id = int.Parse(reader[0].ToString()),
                        id_carrera = int.Parse(reader[1].ToString()),
                        materia = reader[2].ToString(),
                        //
                        //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                        categoria = reader[3].ToString(),
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

        public IActionResult Create(int id)
        {
           // id=ViewBag.id;
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(incumbencia mov ,int id)
        //public async Task<IActionResult> Create(CarreraIma mov)
        {
            try
            {

                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                string queryString = "INSERT INTO Incumbencia (Id_carrera, materia, categoria) VALUES ( @Id_carrera, @materia, @categoria);";
                //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                //toma los parametros obtenidos para despues agregarlos en el consulta sql
                command.Parameters.AddWithValue("@Id_carrera", id);
                ///command.Parameters.AddWithValue("@Id_carrera", ViewBag.Id);
                command.Parameters.AddWithValue("@materia", mov.materia);
                command.Parameters.AddWithValue("@categoria", mov.categoria);

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
                string queryString = "Select * from incumbencia Where Id=@Id";
                //string queryString = "INSERT INTO carrera (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                //necesario hacer este para que sepa a que id filtrar
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    incumbencia movieADOs = new incumbencia()
                    {
                        Id = int.Parse(reader[0].ToString()),
                        id_carrera = int.Parse(reader[1].ToString()),
                        materia = reader[2].ToString(),
                        //
                        //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                        categoria = reader[3].ToString(),
                    };
                    return View(movieADOs);

                    // list.Add(movieADOs);
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
        /*

        [HttpPost]
        [ValidateAntiForgeryToken]
        //esto seria editor pero el editor sin httpost es lo mismo que el de arriba. ademas un poco de variedad
        public async Task<IActionResult> Detalle(int id, incumbencia mov)
        {

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string queryString = "update incumbencia   set  materia=@materia, categoria=@categoria where Id = @id";
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
                string queryString = "Select * from incumbencia Where Id=@Id";
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
        */

    }
}
