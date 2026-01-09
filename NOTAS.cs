namespace notas
{
    public class ReproductorMusical
    {
        private Dictionary<string, int> Frecuencias;
        private Dictionary<string, double> Duraciones;

        public ReproductorMusical()
        {
            Frecuencias = new Dictionary<string, int>()
            {
                {"DO", 262},
                {"RE", 294},
                {"MI", 330},
                {"FA", 349},  
                {"SOL", 392},
                {"LA", 440 },
                {"SI", 494},
            };

            Duraciones = new Dictionary<string, double>()
            {
                {"redonda", 4.0},
                {"blanca", 2.0},
                {"negra", 1.0},
                {"corchea", 0.5},
                {"semicorchea", 0.25}
            };
        }

        public void CambiarTempo(double nuevaDuracion)
        {

            if(nuevaDuracion < 0.1 || nuevaDuracion > 5.0)
            {
                throw new Exception ("El valor debe de ser entre 0.1 y 5.0");
            }

            Duraciones ["negra"] = nuevaDuracion;

            Duraciones ["redonda"] = nuevaDuracion * 4;
            Duraciones ["blanca"] = nuevaDuracion * 2;
            Duraciones ["corchea"] = nuevaDuracion / 2;
            Duraciones ["semicorchea"] = nuevaDuracion / 4;
        }

        public int ObtenerFrecuencia(string nota)
        {
            string notaMayuscula = nota.ToUpper();

            if (Frecuencias.ContainsKey(notaMayuscula))
            {
                return Frecuencias[notaMayuscula] ;
            }

            throw new Exception("La nota no se encuentra") ;
        }

        public int ObtenerMs(string figura)
        {
            string figuraMinuscula = figura.ToLower();

            if (Duraciones.ContainsKey(figuraMinuscula))
            {
                return (int)(Duraciones[figuraMinuscula] * 1000);
            }

            throw new Exception("La figura no se encuentra");
        }


    }
}




