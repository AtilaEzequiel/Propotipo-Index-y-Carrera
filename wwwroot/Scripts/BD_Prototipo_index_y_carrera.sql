/*
No se encontraron propiedades extendidas de nivel de base de datos o todas las propiedades extendidas existentes están abiertas en otras ventanas.
*/CREATE TABLE [dbo].[Carreras] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]       NVARCHAR (100) NULL,
    [Descripcion]  NVARCHAR (MAX) NOT NULL,
    [Duracion]     INT            NOT NULL,
    [Titulo]       NVARCHAR (100) NOT NULL,
    [Incumbencias] NVARCHAR (MAX) NOT NULL,
    [Imagen]       NVARCHAR (100) NOT NULL,
    [Categoria]    NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

INSERT INTO [dbo].[Carreras] ([Id], [Nombre], [Descripcion], [Duracion], [Titulo], [Incumbencias], [Imagen], [Categoria]) VALUES (7002, N'analista de sistemas', N'El Analista de sistemas de información  está capacitado para desempeñarse en forma autónoma o en relación de dependencia, como:  Miembro de departamentos de sistemas en organizaciones industriales, comerciales y de servicios. Integrante de equipos de programación de sistemas de información y comunicación en cuanto a planificación, diseño y desarrollo de los mismos. Desarrollador e implementador de sistemas informáticos computarizados. Asesor en la selección de los recursos humanos necesarios para el desarrollo de los sistemas de información y la adquisición de hardware y software', 3, N'analista de sistemas de información', N'programaicon', N'indexuniverso2.jpg', N'Carrera')

CREATE TABLE [dbo].[Incumbencia] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Id_carrera] INT           NOT NULL,
    [materia]    VARCHAR (100) NOT NULL,
    [categoria]  VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Id_carrera]) REFERENCES [dbo].[Carreras] ([Id])
);

-- INSERT INTO [dbo].[Incumbencia] ([Id], [Id_carrera], [materia], [categoria]) VALUES (1015, 6020, N'dwa', N'incumbencia')
INSERT INTO [dbo].[Incumbencia] ([Id], [Id_carrera], [materia], [categoria]) VALUES (2002, 7002, N'Programacion', N'incumbencia_1')
INSERT INTO [dbo].[Incumbencia] ([Id], [Id_carrera], [materia], [categoria]) VALUES (3002, 7002, N'Programacion 2', N'incumbencia_1')
INSERT INTO [dbo].[Incumbencia] ([Id], [Id_carrera], [materia], [categoria]) VALUES (3003, 7002, N'Programacion 3', N'incumbencia_2')

CREATE TABLE [dbo].[Preguntas] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Pregunta]  NVARCHAR (100) NULL,
    [Respuesta] NVARCHAR (100) NULL,
    [Categoria] NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

SET IDENTITY_INSERT [dbo].[Preguntas] ON
INSERT INTO [dbo].[Preguntas] ([Id], [Pregunta], [Respuesta], [Categoria]) VALUES (1, N'Como me inscribo?', N'mediante este links', N'Pregunta')
INSERT INTO [dbo].[Preguntas] ([Id], [Pregunta], [Respuesta], [Categoria]) VALUES (2, N'donde encuentro el instituto superrioir nuestra se', N'en piedrabueno al 12456', N'Pregunta')
INSERT INTO [dbo].[Preguntas] ([Id], [Pregunta], [Respuesta], [Categoria]) VALUES (3, N'quien es galo', N'el mejor', N'Pregunta')
INSERT INTO [dbo].[Preguntas] ([Id], [Pregunta], [Respuesta], [Categoria]) VALUES (4, N'quien es galo', N'el mejor', N'Pregunta')
INSERT INTO [dbo].[Preguntas] ([Id], [Pregunta], [Respuesta], [Categoria]) VALUES (6, N'dasdasd', N'asad', N'Pregunta')
INSERT INTO [dbo].[Preguntas] ([Id], [Pregunta], [Respuesta], [Categoria]) VALUES (1002, N'cuantos años son', N'3', N'Pregunta')
INSERT INTO [dbo].[Preguntas] ([Id], [Pregunta], [Respuesta], [Categoria]) VALUES (2002, N'hola?', N'holangsa', NULL)
INSERT INTO [dbo].[Preguntas] ([Id], [Pregunta], [Respuesta], [Categoria]) VALUES (2003, N'hola?', N'holangsaaaaaa', NULL)
INSERT INTO [dbo].[Preguntas] ([Id], [Pregunta], [Respuesta], [Categoria]) VALUES (3002, N'hola?????', N'holangsaaaaaaasas', N'Pregunta')
SET IDENTITY_INSERT [dbo].[Preguntas] OFF

