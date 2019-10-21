# Taller PICA01 WebMVC

## Refactorización projectos
* Web -> mvc/api -> Aplicación Web
* Core -> classlib -> Servicios de lógica de negocio
* Data -> classlib -> Persitencia, modelo de datos, componentes de Entity Framework
* WebTests -> proyectos de pruebas unitarias -> Pruebas de integración del proyecto web, 
* CoreTests -> proyectos de pruebas unitarias -> Pruebas unitarias del proyecto Core

## Configuración
* Entornos de ejecución
  - Development -> Se ejecuta en puerto 5300 y 5301
  - Production -> Se ejecuta en puerto 5400 y 5401
  - QA -> Se ejecuta en puerto 5500 y 5501
  
## Persistencia de datos
* Uso de base de datos en memoria

## Pruebas
* Pruebas unitarias del servicio de Contactos con Mock del repositorio
* Pruebas de integración de las paginas de la aplicación web
  - Prueba de respuesta correcta de páginas del sitio
  - Prueba de páginas que requieren autorización
  - Prueba de página que no existe

## MVC
* Página de bienvenida con encabezado, pie de página y menú de navegación
* Autenticación básica sin almacenamiento o validacion de contraseña (se puede ingresar con cualquier correo y contraseña)
  * Cualquier dirección de correo pertenece al rol **Member** excepto la dirección anonymous@test.com 
* Página de bienvenida de usuario (solo accesible despues de autenticar)
* Página de formulario de contacto con validación de campos
* Página de agradecimiento al actualizar los datos de contacto
* Página personalizada de errores 

## WebApi
* Controlador con metodo POST para recibir los datos del formulario de contacto **/api/contact**
* Soporte para negociación de contenido para producir y consumir XML y JSON 
