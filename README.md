PRUEBA TÉCNICA
Descripción general: Este proyecto implementa la prueba técnica utilizando una arquitectura Backend for Frontend (BFF) con .NET 8 y un frontend en Angular 19.
El objetivo es consumir la API pública de Rick and Morty, obtener episodios y mostrarlos con paginación.
Se aplican buenas prácticas, separación de capas, uso de DTOs y manejo de errores.

Tecnologías utilizadas:
Backend:
.NET 8
ASP.NET Core Web API
C#
Swagger

Frontend:
Angular 19
TypeScript
Standalone Components
Angular Signals
HttpClient
CSS puro (sin frameworks)

Estructura del repositorio:
PruebaTecnicaCarsales/
Carsales.RickAndMorty.BFF
Clients (cliente HTTP hacia API externa)
Services (lógica de negocio)
Models (DTOs y modelos)
Endpoints (endpoints expuestos al frontend)
Program.cs (configuración general, CORS, Swagger)

frontend
carsales-rickandmorty-web
src/app/episodes (componente de episodios)
src/app/services (EpisodesService)
src/app/models (modelos tipados)


Requisitos previos:
.NET 8 SDK
Node.js 18 o superior
npm
Angular CLI (opcional, no obligatorio)

Cómo ejecutar el backend:
Abrir el proyecto Carsales.RickAndMorty.BFF en Visual Studio
o ejecutar en consola:
cd Carsales.RickAndMorty.BFF
dotnet run

Backend disponible en:
https://localhost:7106

Swagger disponible en:
https://localhost:7106/swagger

Endpoint principal del BFF:
GET /api/episodes?page={page}

Ejemplo de respuesta:
{
"page": 1,
"totalPages": 3,
"totalCount": 51,
"items": [
{
"id": 1,
"name": "Pilot",
"airDate": "December 2, 2013",
"episodeCode": "S01E01"
}
]
}

Cómo ejecutar el frontend:
Ir al proyecto Angular:
cd frontend/carsales-rickandmorty-web
Instalar dependencias:
npm install

Ejecutar:
ng serve -o

URL del frontend:
http://localhost:4200

Nota: El backend debe estar ejecutándose para que los episodios carguen.

Arquitectura BFF:
El frontend no consume directamente la API pública.
Todo pasa por el BFF, que:
Llama a la API de Rick and Morty

Normaliza datos
Expone un endpoint simple y estable al frontend
Componentes principales del BFF:
RickAndMortyApiClient: realiza la llamada HTTP externa
EpisodeService: lógica de negocio y mapeo de datos
Endpoints: exponen /api/episodes al frontend

Paginación:
El backend recibe "page" y consulta la API externa.
Normaliza totalPages, totalCount y items.
El frontend mantiene currentPage mediante Signals.
Botones deshabilitados cuando corresponde.
Estado de loading implementado.

Manejo de errores:
Frontend:
Mensaje “Cargando…”
Mensaje de error si el backend no responde
Botones deshabilitados mientras se carga

Backend:
Validación de errores de la API externa
Mapeo de mensajes claros para el frontend
Decisiones de diseño:
Separación clara entre Client, Service, Endpoints
DTOs para evitar exponer modelos externos
Tipado estricto en Angular
Signals para estado simple
Standalone components en Angular 19
CORS habilitado correctamente para localhost:4200

Carlos Rivera Fuentes
+56 9 6117 4256
carlosriverafue@gmail.com
