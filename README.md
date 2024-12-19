Mapa con Marcador a  Imagen

Este proyecto es una aplicación de escritorio desarrollada en C# y Windows Forms que utiliza la biblioteca GMap.NET para trabajar con mapas interactivos. La aplicación permite establecer marcadores en un mapa basándose en coordenadas geográficas proporcionadas como argumentos de entrada y captura la vista actual del mapa en una imagen, que se guarda en el sistema de archivos.

Características
Integración con GMap.NET: Utiliza el proveedor de mapas de Google para mostrar y personalizar mapas interactivos.
Personalización de marcadores: Añade marcadores en una posición específica utilizando coordenadas geográficas.
Captura de mapas: Genera una imagen del mapa visible con los marcadores añadidos.
Modo automático: Cierra la aplicación automáticamente tras guardar la imagen, si se especifica en los argumentos.
Validación robusta de entrada: Maneja errores relacionados con argumentos insuficientes o inválidos.
Requisitos
.NET Framework o .NET Core (compatible con la versión del proyecto).
Biblioteca GMap.NET.
Sistema operativo Windows.
Configuración y Uso
Clona el repositorio:
bash
Copiar código
git clone https://github.com/tuusuario/map-marker-image-capture.git
Abre el proyecto en Visual Studio.
Instala las dependencias necesarias:
Asegúrate de incluir la referencia a la biblioteca GMap.NET.
Proporciona los argumentos al ejecutar la aplicación:
Formato:
scss
Copiar código
/latitud/longitud/ruta_del_archivo/autoclose(opcional)
Ejemplo:
bash
Copiar código
/-2.1551116/-79.8907303/C:\temp\mapa.png/autoclose
Tecnologías utilizadas
Lenguaje: C#
Interfaz gráfica: Windows Forms
Biblioteca de mapas: GMap.NET
Gestión de imágenes: System.Drawing
Funcionamiento principal
Recibe las coordenadas y una ruta de archivo como argumentos.
Muestra el mapa centrado en las coordenadas dadas.
Agrega un marcador en la posición indicada.
Captura la vista del mapa y guarda la imagen en la ruta especificada.
Opcionalmente, cierra la aplicación automáticamente después de guardar la imagen.
Contribuciones
Las contribuciones son bienvenidas. Si encuentras errores o tienes sugerencias para mejorar la funcionalidad, no dudes en abrir un issue o enviar un pull request.

Licencia
Este proyecto está licenciado bajo la MIT License. Consulta el archivo LICENSE para más detalles.
