CREATE DATABASE ONG

USE ONG


CREATE TABLE Adotante(
	Nome varchar(50) NOT NULL,
	CPF varchar(11) NOT NULL,
	Sexo char(1)  NOT NULL,
	DataNascimento date Not NULL,
	
	Telefone varchar (11) NOT NULL

	CONSTRAINT PK_CPF_Adotante PRIMARY KEY (CPF)
	);

CREATE TABLE Adotado(
	CHIP int identity,
	Familia varchar(30)NOT NULL,
	Raca varchar(20)NOT NULL,
	Sexo char(1)NOT NULL,
	Nome varchar(50)
	CONSTRAINT PK_CHIP_Adotado PRIMARY KEY (CHIP)
);

CREATE TABLE Adocao(
CPF varchar(11) not null,
CHIP int not null,
DataAdocao date not null,

FOREIGN KEY (CPF) references Adotante(CPF),
FOREIGN KEY (CHIP) references Adotado(CHIP),
CONSTRAINT PK_Adocao PRIMARY KEY (CPF,CHIP)
);

CREATE TABLE Endereco(
	CPF varchar(11) NOT NULL,
	Logradouro varchar(50) NOT NULL,
	CEP varchar(8)NOT NULL,
	Complemento varchar(20),
	Numero int NOT NULL,
	Bairro varchar(30) NOT NULL,
	Cidade varchar(30) NOT NULL,
	Estado char(2) NOT NULL,

	FOREIGN KEY (CPF) REFERENCES Adotante(CPF)
);

--ver se está tudo ok nas tabelas
Select * from adotado;
select * from adotante;
select * from Adocao;
select * from endereco;
