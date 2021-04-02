# Iniciando FrontEnd 

FrontEnd construido com ReactJs

Primeiro precisa ter o NodeJS instalado.


## Dentro da pasta frontend rode os seguinte comando 

Para instalar as dependencias do projeto.
### `npm install`

Para iniciar o projeto.
### `npm start`

O projeto inciara por padrão em http://localhost:3000/

Caso a porta 3000 ja esteja sendo usada ele ira sugerir a proxima porta na sequencia, e pedira por confirmação.


# Iniciando o BackEnd

Construido com C# como solicitado.

Contruido com o maximo do principio de SOLID possivel.

Foram definidas 2 rotas: 

Receber o arquivo e response se falha ou sucesso.

### `POST : /api/Upload`

Lista os arquivos que ja foram feitos as mudanças, disponibilizando para download.

### `GET: /api/Upload/<nome-do-arquivo>`


# Importante!!

Apenas lembrando que o frontend esta configurado para fazer as requisiçoes na API C# com endereço: http://localhost:53636, sendonecessario caso a porta mude a alteração do codigo do frontend.

