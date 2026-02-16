## Como Executar o Projeto

### Pré-requisitos

* Ter o [**.NET 8 SDK**](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0) instalado em sua máquina.

### Passos para execução

1.  Clonar o repositório:
    ```bash
    git clone [https://github.com/WilliamHermann/TestePratico.git](https://github.com/WilliamHermann/TestePratico.git)
    ```
    OU clonar pela própria interface do Github

2.  Navegar até a pasta do projeto principal:
    ```bash
    cd TestePratico/TestePratico.API
    ```

3.  Compilar projeto e dependências
    ```bash
    dotnet build
    ```

4.  Execute a aplicação:
    ```bash
    dotnet run
    ```

### Acessando a Documentação (Swagger)

Com a aplicação em execução, acesse a interface do Swagger para testar os endpoints:

### Exemplo de JSON para cadastro

{
  "descricao": "Carro econômico, pneus novos",
  "marca": "Fiat",
  "modelo": "Uno Mille",
  "valor": 100000.00
}
