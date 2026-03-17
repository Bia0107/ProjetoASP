create database dbBancoApp;
use dbBancoApp;

create table tbUsuario(
IdUsu int primary key auto_increment,
NomeUsu varchar(50) not null,
Cargo varchar(50) not null,
DataNasc datetime
);

insert into tbUsuario(NomeUsu,Cargo,DataNasc)
				values('Nilson','Gerente','1978/05/01'),
					  ('Bruno','Colaborador','2000/10/12');	
select * from tbUsuario;
