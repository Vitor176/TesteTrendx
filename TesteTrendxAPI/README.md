Processo Seletivo Trendx Criação de API de TASK

Para nossa API funcionar corretamente seguir o passo a passo

Atualize a connectionString para que seja feita a requisição em sua base de dados local.
<img width="908" alt="image" src="https://github.com/Vitor176/TesteTrendx/assets/56492256/f7e6b41c-c29a-48f2-8193-9fd6c5252e67">

Vale ressaltar para que na connectionstring tenha a base de dados que você irá utilizar, senão houver nenhuma execute o comando 

CREATE DATABASE *NOME_DA_BASE*

Logo após, vá na solução da API e abra o terminal como mostra a imagem a seguir : 

<img width="390" alt="image" src="https://github.com/Vitor176/TesteTrendx/assets/56492256/646ca054-b87f-460e-afe6-10a9cf05977b">

Ao abrirmos o projeto em nosso terminal, execute o comando

dotnet ef database update

para que nossa base de dados seja atualizada com as informações das models, caso utilize já alguma base existente que já tenha alguma initialMigration, solicito para que execute o comando abaixo:

  DROP TABLE dbo.__EFMigrationsHistory

  para que exclua o histórico de migration e o entity não identifique que já existe uma migration com o mesmo nome.

Feito isso finalizamos nossa configuração de ambiente para que possamos executar nossa API 
