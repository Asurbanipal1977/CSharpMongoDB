### MONGODB Y C#

MongoDB es una base de datos no relacional que guarda los datos en collecciones en formato bson. Ej de comando:
[mongodb-queries-examples](https://geekflare.com/es/mongodb-queries-examples/)

Para poder usarlo en C#:
- Instalar CompassDb o RoboMongo.
- Instalar el [servidor local](https://www.mongodb.com/try/download/community)
- Instalar desde consola el paquete de MongoDB:
Install-Package MongoDB.Driver
- Creamos una clase que nos sirva para mapear la colección de Mongo.
- Se coloca la conexión a base de datos (que es mongodb://localhost:27017)

Para crear un API:
- Desde la versión 5.0 se tiene la posibildiad de activar OpenAPI y así poder usar swagger.
- Creamos una clase que nos sirva para mapear la colección de Mongo.
- Se añade en el json las variables para la conexión:
```
"PeopleSettings": {
    "Server": "localhost:27017",
    "Database": "school",
    "Collection":  "people"
  }
```
- Se inyecta en Startup la configuración:
```
services.Configure<PeopleSettings>(Configuration.GetSection(nameof(PeopleSettings)));
services.AddControllers();
//Inyecta las opciones de configuración con el servidor y demás
services.AddSingleton<ISettings>(c=> c.GetRequiredService<IOptions<PeopleSettings>>().Value);
```
- Se crea el servicio que accede a mongo y se inyecta.
