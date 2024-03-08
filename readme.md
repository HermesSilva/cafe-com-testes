                                                                   #  Desafio de Cálculo de Resgate de CDB

Este repositório contem os arquivo que envolvem o projeto para calcular o resgate do CDB.

Status do repositório 
[![Build-Tests](https://github.com/hermessilva/DesafioCDB/actions/workflows/CI-CD.yml/badge.svg?branch=main)](https://github.com/hermessilva/DesafioCDB/actions/workflows/CI-CD.yml) 
<table>
  <tr>
    <th></th>
    <th>Tecnologia</th>
    <th>Versão</th>
    <th>Ferramentas/Link</th>    
  </tr>
  <tr>
    <td><img align="center" alt="Rafa-Csharp" height="30" width="40" src="https://icongr.am/devicon/dot-net-original.svg?size=40"></td>
    <td>.Net Core</td>
    <td>8.0</td>
    <td>
	<a href="https://dotnet.microsoft.com/en-us/download/dotnet/8.0">.NET 8.0</a>, 
    <a href="https://xunit.net/">xUnit</a>, 
    <a href="https://fluentvalidation.net">FluentValidation</a> </td>
  </tr>
  <tr>
    <td><img align="center" alt="Rafa-Csharp" height="30" width="40" src="https://icongr.am/devicon/csharp-original.svg?size=40"></td>
    <td>C#</td>
    <td>12.0</td>
    <td><a href="https://learn.microsoft.com/en-us/dotnet/csharp/">CSharp 12</a></td>    
  </tr>    
  <tr>
    <td><img align="center" alt="Rafa-Csharp" height="30" width="40" src="https://icongr.am/devicon/visualstudio-plain.svg?size=40"></td>
    <td>Visual Studio</td>
    <td>2022 Community</td>
    <td><a href="https://visualstudio.microsoft.com/vs/community/">Community</a></td>    
  </tr>  
  <tr>
    <td><img align="center"alt="Rafa-Csharp" height="30" width="40" src="https://nodejs.org/static/images/logo.svg?size=40"></td>
    <td>NodeJS</td>
    <td></td>
    <td><a href="https://nodejs.org/en">Node JS</a></td>    
  </tr> 
  <tr>
    <td><img align="center" alt="Rafa-Csharp" height="30" width="40" src="https://angular.io/assets/images/logos/angular/angular.svg?size=40"></td>
    <td>Angular</td>
    <td>Angular v12</td>
    <td><a href="https://angular.io/">Angular</a></td>    
  </tr>    
  <tr>
    <td><img align="center" alt="Rafa-Csharp" height="30" width="40" src="https://upload.wikimedia.org/wikipedia/commons/thumb/f/f5/Typescript.svg/64px-Typescript.svg.png?size=40"></td>
    <td>TypeScript</td>
    <td>5.3</td>
    <td><a href="https://www.typescriptlang.org/">TypeScript</a></td>    
  </tr>  
  <tr>
    <td><img align="center" alt="Rafa-Csharp" height="30" width="40" src="https://github.githubassets.com/assets/GitHub-Mark-ea2971cee799.png?size=40"></td>
    <td>GitHub</td>
    <td></td>
    <td><a href="https://github.com/">GitHub</a></td>    
  </tr> 

  <tr>
    <td><img align="center" alt="Rafa-Csharp" height="30" width="40" src="https://icongr.am/devicon/git-original.svg?size=40"></td>
    <td>Git</td>
    <td>lasted</td>
    <td><a href="https://git-scm.com/downloads">Git</a></td>    
  </tr>  
</table>

## Pré-requisitos para a instalação do projeto:

+ Angular v12
+ NET 8.0
+ Git

## Instalação do projeto e configuração do ambiente:

1. Clonar o repositório:
   
   `
   git clone https://github.com/HermesSilva/ResgateCDB.git
   `

2. Entrar no diretório criado:
   
   `
   cd ResgateCDB
   `

4. Executar Testes
   
   `
   dotnet test ResgateCDB.sln
   `

5. Executar Cliente em Angular
   
   `
   StartClient
   `

5. Executar Servidor C#, WebAPI
   
   `
   StartServer
   `

A client em Angular, não está preparado para ser acessa de uma URL diferente de LOCALHOST