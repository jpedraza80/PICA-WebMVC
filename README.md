# Taller PICA01 WebMVC


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
