using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Propotipo_Index_y_Carrera.Models;
using System.Collections;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Propotipo_Index_y_Carrera.Controllers
{
    public class CarreraController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment Environment;
        public CarreraController(ILogger<HomeController> logger, IWebHostEnvironment _environment)
        {
            _logger = logger;
            Environment = _environment;
        }
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BD_Prototipo_index_y_carrera;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        // guardo lo necesario para conectar a la base de datos en un string para despues pegar el string y listo
        List<Carreras> list = new List<Carreras>();
        //select c.*, i.materia, i.categoria from Carreras c inner join Incumbencia i on (c.Id= i.Id_carrera)
        List<CarreraDetalle> list1 = new List<CarreraDetalle>();
        //select * from IndexHome i
        //inner join Carreras c on i.Id_carrera=c.Id
        //where c.id= '2'
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
                string queryString = "select * from Carreras ";
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

                    /*
                    Carreras PregADOs = new Carreras()
                    {
                        //guarda por elemento del modelo carrera
                        Id_carrera = int.Parse(reader[0].ToString()),
                        nombre = reader[1].ToString(),
                        //
                        //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                        Description = reader[2].ToString(),
                        Duracion =int.Parse( reader[3].ToString()),
                        Titulo = reader[4].ToString(),
                        Incumbencias = reader[5].ToString(),
                        Imagen = reader[6].ToString(),
                        categotia = reader[7].ToString(),
                        
                    };
                        */
                    CarreraDetalle pregaDetalle = new CarreraDetalle()
                    {
                        //guarda por elemento del modelo carrera
                        Id_carrera = int.Parse(reader[0].ToString()),
                        nombre = reader[1].ToString(),
                        //
                        //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                        Description = reader[2].ToString(),
                        Duracion = int.Parse(reader[3].ToString()),
                        Titulo = reader[4].ToString(),
                        Incumbencias = reader[5].ToString(),
                        Imagen = reader[6].ToString(),
                        categotia = reader[7].ToString(),
                        //materia= reader[8].ToString(),
                        
                    };
                        

                        //Imagen = "https://drive.google.com/uc?export=view&id=" + reader[3].ToString(),
                        //Imagen = reader[3].ToString()

                        //  Price = int.Parse(reader[4].ToString()),
                    
                    
                    //guarda en la lista
                    list1.Add(pregaDetalle);
                    //  list.Add(movieADOs);
                    // return View(movieADOs);

                    //  list.Add(movieADOs);
                    //list.Add(movieADOs1);
                }


                //cierrra la conexion
                connection.Close();
                //muestra la lista de resutltado
                return View(list1);

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
        public async Task<IActionResult> Create(Carreras mov, List<IFormFile> postedFiles)
        //public async Task<IActionResult> Create(CarreraIma mov)
        {
            try
            {
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                string path = Path.Combine(this.Environment.WebRootPath, "uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                List<string> uploadedFiles = new List<string>();
                string alfa="algo";
                foreach (IFormFile postedFile in postedFiles)
                {
                    string fileName = Path.GetFileName(postedFile.FileName);
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                        uploadedFiles.Add(fileName);
                        ViewBag.Message += fileName + ",";
                        alfa = postedFile.FileName;
                    }
                }
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                string queryString = "INSERT INTO Carreras ( nombre, Descripcion, Duracion, Titulo, Incumbencias, imagen, Categoria) VALUES ( @nombre, @Descripcion, @Duracion, @Titulo, @Incumbencias, @Imagen,@Categoria);";
                //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                //toma los parametros obtenidos para despues agregarlos en el consulta sql
                command.Parameters.AddWithValue("@nombre", mov.nombre);
                command.Parameters.AddWithValue("@Descripcion", mov.Description);
                command.Parameters.AddWithValue("@Duracion", mov.Duracion);

                command.Parameters.AddWithValue("@Titulo", mov.Titulo);

                command.Parameters.AddWithValue("@Incumbencias", mov.Incumbencias);
                command.Parameters.AddWithValue("@Imagen", alfa);
                command.Parameters.AddWithValue("@Categoria", "Carrera");

                //ViewBag.id = 4002;


                SqlDataReader reader = command.ExecuteReader();


                connection.Close();
                incu( mov);
                //SqlConnection connection = new SqlConnection(connectionString);


                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        
        public ViewResult incu(Carreras mov)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string queryString = "select c.Id from Carreras c Where Nombre=@nombre and Descripcion=@Descripcion and Duracion=@Duracion and Titulo=@Titulo and Incumbencias=@Incumbencias";
            //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
            SqlCommand command = new SqlCommand(queryString, connection);
            //  command.ExecuteReader(queryString);
            //toma los parametros obtenidos para despues agregarlos en el consulta sql
            command.Parameters.AddWithValue("@nombre", mov.nombre);
            command.Parameters.AddWithValue("@Descripcion", mov.Description);
            command.Parameters.AddWithValue("@Duracion", mov.Duracion);

            command.Parameters.AddWithValue("@Titulo", mov.Titulo);

            command.Parameters.AddWithValue("@Incumbencias", mov.Incumbencias);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ViewBag.id = int.Parse(reader[0].ToString());
                
                
                
              //  list.Add(PregADOs);
                //list.Add(movieADOs1);
            }


            connection.Close();
            return View();
        }

        /*
        [HttpPost]
        public IActionResult Index(List<IFormFile> postedFiles)
        {
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine(this.Environment.WebRootPath, "uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                    ViewBag.Message += fileName + ",";
                }
            }
            return View();
        }

        */
        public ActionResult Detalle(int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                //filtra por id
                string queryString = "select c.*, i.materia, i.categoria, i.Id_carrera from Carreras c inner join Incumbencia i on (c.Id= i.Id_carrera) Where c.Id=@Id";
                //string queryString = "INSERT INTO carrera (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                //necesario hacer este para que sepa a que id filtrar
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CarreraDetalle PregADOs = new CarreraDetalle()
                    {
                        //guarda por elemento del modelo carrera
                        Id_carrera = int.Parse(reader[0].ToString()),
                        nombre = reader[1].ToString(),
                        //
                        //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                        Description = reader[2].ToString(),
                        Duracion = int.Parse(reader[3].ToString()),
                        Titulo = reader[4].ToString(),
                        Incumbencias = reader[5].ToString(),
                        Imagen = "/uploads/" + reader[6].ToString(),
                        categotia = reader[7].ToString(),
                        materia = reader[8].ToString(),
                        categotia_materia = reader[9].ToString(),
                        Id_carrerai =int.Parse( reader[10].ToString()),



                        //Imagen = "https://drive.google.com/uc?export=view&id=" + reader[3].ToString(),
                        //Imagen = reader[3].ToString()

                        //  Price = int.Parse(reader[4].ToString()),
                    };
                    

                      list1.Add(PregADOs);
                    //list.Add(movieADOs1);
                }



                connection.Close();
                return View(list1);

            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //esto seria editor pero el editor sin httpost es lo mismo que el de arriba. ademas un poco de variedad
        public async Task<IActionResult> Detalle(int id, Carreras mov)
        {

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string queryString = "update Carreras   set  Nombre=@nombre, Descripcion=@Descripcion where Id = @id";
                //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@nombre", mov.nombre);
                command.Parameters.AddWithValue("@Descripcion", mov.Description);
                

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

        public IActionResult Delete(int id, Carreras mov)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string queryString = "Select * from Carreras Where Id=@ID";
                //string queryString = "INSERT INTO carrera (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Carreras movieADOs = new Carreras()
                    {
                        //guarda por elemento del modelo carrera
                        Id_carrera = int.Parse(reader[0].ToString()),
                        nombre = reader[1].ToString(),
                        //
                        //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                        Description = reader[2].ToString(),
                        Duracion = int.Parse(reader[3].ToString()),
                        Titulo = reader[4].ToString(),
                        Incumbencias = reader[5].ToString(),
                        Imagen = "/uploads/" + reader[6].ToString(),
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string queryString = "delete from Carreras where Id = @Id";
                //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                command.Parameters.AddWithValue("@Id", id);


                // SqlDataReader reader = command.ExecuteReader();
                SqlDataReader reader = command.ExecuteReader();


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
