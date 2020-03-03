create table materias(
id_Materia int identity primary key,
nombre varchar(25),
nivel int
)

create table estudiantes(
id_Estudiante int identity primary key,
nombre varchar(25),
apellido varchar(25),
email varchar(256),
id_Materia int
foreign key (id_Materia) references materias (id_Materia)
)