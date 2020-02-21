--DML

INSERT INTO Funcionarios (Nome, Sobrenome)
VALUES ('Catarina','Strada'),
	   ('Tadeu','Vitelli')
	   
ALTER TABLE Funcionarios Add DataNascimento DATE

INSERT INTO Funcionarios (Nome, Sobrenome, DataNascimento)
VALUES ('Catarina','Strada','10/10/1990'),
	   ('Tadeu','Vitelli','11/12/1889')
