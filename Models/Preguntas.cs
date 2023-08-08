namespace Propotipo_Index_y_Carrera.Models
{
    public class Pregunta
    {
        public int Id_Pregunta { get; set; }
        public string Pregunt { get; set; }
        public string Respuesta { get; set; }

        public string pregunta_categoria { get; set; }
    }

/*
    
    public class Carrera
    {
        public int Id_carrera { get; set; }
        public string nombre { get; set; }
        public string Description { get; set; }

        public int Duracion { get; set; }

        public string Titulo { get; set; }
        public string Incumbencias { get; set; }

        public string Imagen { get; set; }

        public string pregunta_categoria { get; set; }





    }


    public class Preguntasmodel
    {
        public Carrera Carreraslist { get; set; }

         public Pregunta Preguntaslist { get; set;}

        // public List<Carrera> CarrerasList { get; set; } 

        //   public List<Pregunta> PreguntasList { get; set;}

        // public List<Carrera> CarrerasList { get; set; } 

        //   public List<Pregunta> PreguntasList { get; set;}
    }

    */

}
