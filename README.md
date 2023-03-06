==================================================
LINK YAHOO FINANCE UTILIZADO PARA ACESSAR OS DADOS
==================================================
https://query1.finance.yahoo.com/v8/finance/chart/PETR4.SA?symbol=PETR4.SA&period1=1675422000&period2=9999999999&interval=1d
- Período inicial: 03/02/2023
- Período final: 03/03/2023
- Intervalo: 1 dia (abertura)

===================================
COMANDOS BANCO DE DADOS SQL SERVER
===================================
USE [master]
GO

* Criando base da dados *
CREATE DATABASE [YAHOO_FINANCE]
GO

USE [YAHOO_FINANCE]
GO

* Criando tabela para armazenar os dados *
CREATE TABLE [TB_PETR4_DAILY]
(
    [ID] INT PRIMARY KEY IDENTITY(1,1),
    [CL_DATE] DATETIME NOT NULL,
    [CL_VALUE] FLOAT NOT NULL,
    [CL_VARIATION_PREVIOUS_DATE] FLOAT NOT NULL,
    [CL_VARIATION_FIRST_DATE] FLOAT NOT NULL,
)
GO

=======================
DOCUMENTAÇÃO DAS API's
=======================
(POST) '/YahooFinance/PETR4/Insert/' - API que consome os dados do Yahoo Finance, manipula e insere da forma correta no banco de dados apenas os campos necessários.
(GET) '/YahooFinance/PETR4/Historic30Days/' - API que busca os dados no banco de dados e nos retorna as informações sobre as variações do PETR4 dos útlimos 30 dias.

- Id: Identity, auto-incremental pelo banco de dados.
- Date: Data analisada.
- Value: Valor (em BRL) da ação no dia.
- VariationPreviousDate: Variação (em %) do valor da ação em relação ao dia anterior (D-1).
- VariationFirstDate: Variação (em %) do valor da ação em relação a primeira data analisada (03/02/2023).

=======================
COMO UTILIZAR AS API'S
=======================
Para utilizar as API's deverá ser utilizado alguma ferramente para requisições de API's. Como por exemplo Postman, ou a extensão do VSCode Thunder Client.
Após executar o programa com o comando 'dotnet run', uma porta local será apresentada a você.
Concatene essa porta local ao caminho da API e assim os dados serão retornados.

Exemplo: https://localhost:7078/YahooFinance/PETR4/Historic30Days/