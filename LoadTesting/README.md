# <a name="_eugmmqx4qc7e"></a>**Laboratorio 1: Prueba de Carga Básica (Load Testing)**
## <a name="_yubd5hgzgnok"></a>**📝 Descripción**
Este laboratorio tiene como objetivo medir el rendimiento de una API bajo carga normal mediante la herramienta JMeter.
## <a name="_6blljwg7q1hp"></a>**🖥️ Backend**
El backend consiste en un servicio desarrollado en **C# con ASP.NET Core**, que expone un endpoint GET /Products para obtener una lista de productos almacenados en una base de datos MySQL. La base de datos se inicializa con un conjunto de tres datos mediante el archivo init.sql:

INSERT INTO Products (Name, Price) VALUES 

('Laptop', 1200),

('Mouse', 25),

('Keyboard', 45);

## <a name="_yvl7unsbsfh0"></a>**🐳 Dockerización**
Se han creado tres contenedores para este laboratorio:

1. **backend-services**: Contenedor que levanta el backend.
1. **mysql**: Contenedor que gestiona la base de datos MySQL, inicializando los datos con init.sql.
1. **jmeter**: Contenedor que ejecuta el plan de pruebas de carga con JMeter.
## <a name="_2vhmd8l8zy6v"></a>**🏗️ Configuración del Test Plan en JMeter**
JMeter permite crear Test Plans fácilmente con su **GUI**, que simplifica la configuración y guarda todo en un archivo bien estructurado (testplan.jmx).

Las variables definidas en el Test Plan son:

- **API\_URL**: http://backend-services:8000 (en Docker) o http://localhost:8000 (sin Docker).
- **THREAD\_COUNT**: 100 (número de hilos o usuarios concurrentes).
- **RAMP\_UP**: 10 segundos (tiempo en que se distribuirán los usuarios de manera progresiva).
- **LOOP\_COUNT**: 10 (cantidad de repeticiones de cada usuario).
- **REQUEST\_PATH**: /Products (endpoint del backend).
- **RESPONSE\_CODE**: 200 (esperado para respuestas exitosas).
### <a name="_as18d7msn56q"></a>**🔹 Componentes principales del Test Plan**
1. **Thread Group**: Define el número de usuarios, el tiempo de ramp-up y las iteraciones.
1. **HTTP Request**: Realiza la solicitud GET al endpoint /Products.
1. **Listeners**:
   1. **View Results Tree**: Muestra los resultados detallados.
   1. **Graph Results**: Visualiza gráficamente el rendimiento de la API.
## <a name="_y5ojlcswn2v9"></a>**🚀 Ejecución en Docker**
Al levantar el contenedor de JMeter, se ejecuta un script entrypoint.sh con los siguientes pasos:

#!/bin/bash

echo "Esperando 20 segundos para que el backend esté completamente listo..."

sleep 20

echo "Ejecutando JMeter..."

exec jmeter -n -t /jmeter/testplan.jmx -l /jmeter/results.jtl -j /jmeter/jmeter.log -e -o /jmeter/reports



### <a name="_va5zv0ydjgvu"></a>**📌 Explicación:**
- **sleep 20**: Espera 20 segundos para garantizar que el backend esté listo.
- **jmeter -n -t /jmeter/testplan.jmx**: Ejecuta el Test Plan en modo no-GUI.
- **-l /jmeter/results.jtl**: Guarda los resultados en un archivo estructurado.
- **-j /jmeter/jmeter.log**: Guarda un log detallado de la ejecución.
- **-e -o /jmeter/reports**: Genera un informe HTML con gráficas y métricas.
## <a name="_1nw9u0kpidd0"></a>**📊 Resultados**
Los resultados incluyen:

- **results.jtl**: Datos estructurados del rendimiento.
- **jmeter.log**: Registro detallado de la ejecución.
- **reports/**: Reporte HTML con gráficos y métricas.
