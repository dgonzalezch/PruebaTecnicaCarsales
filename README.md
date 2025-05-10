# PruebaTecnicaCarsales

## 🧪 Cómo Probar el Proyecto

Este proyecto se compone de dos partes:

- **Backend:** API REST construida con .NET 8 (ASP.NET Core Web API)  
- **Frontend:** Aplicación SPA desarrollada con Angular 19

---

## 🔧 Requisitos Previos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (versión recomendada: 18.x o superior)
- Angular CLI:

```bash
npm install -g @angular/cli
```

---

## 🚀 Pasos para Ejecutar el Proyecto

### 1️⃣ Iniciar el Backend (.NET 8 API)

1. Abre una terminal y ve al directorio del backend:

```bash
cd backend
```

2. Restaura los paquetes y compila el proyecto:

```bash
dotnet restore
dotnet build
```

3. Ejecuta la API:

```bash
dotnet run
```

La API estará disponible normalmente en: `http://localhost:5201`.

---

### 2️⃣ Iniciar el Frontend (Angular 19)

1. Abre una nueva terminal y ve al directorio del frontend:

```bash
cd frontend
```

2. Instala las dependencias:

```bash
npm install
```

3. Ejecuta la aplicación Angular usando el proxy configurado:

```bash
npm run proxy
```

La aplicación estará disponible en: [http://localhost:4200](http://localhost:4200)

---

✅ Asegurar de tener el backend ejecutándose **antes** de iniciar el frontend para evitar errores de conexión con la API.
