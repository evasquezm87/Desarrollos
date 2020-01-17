##Ejemplo de consumir Web Apí usando Windows Forms##

Pasos Basicos
	* 
Tener la url de la API
	* 
Crear el proyecto
	* 
Crear una clase para almacenar el JSON recibido
	* 
El metodo debe ser Async y de tipo Task<>
	* 
El metodo FormLoad debe cambiarse a Asyn
	* 
Se deben cargar las librerias SysstemNet, System.IO y Newsoft.JSON(Este se descarga de Nuget)



librerias Necesarias
using System.Net;
using System.IO;
using Newtonsoft.Json;

Clase para recibir el JSON, se crea con las propiedades recibidas
 public class PostViewModel
    {
        public string userId { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }

Se coloca la direccion del API en un string, 
Se crea el metodo tipo Async y Task para recibir el resultado
 string url = "https://jsonplaceholder.typicode.com/posts";
        public async Task<string> GetHttp()
        {
            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

Se modifica el metodo a tipo Async
Se convierte el resultado en una lista haciendo la conversion del JSON
