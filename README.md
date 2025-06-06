# Pokemon API (.NET 9)

Este é um projeto de API REST criada com ASP.NET Core (.NET 9) que consome dados da [PokéAPI](https://pokeapi.co/) para **listar e exibir detalhes de Pokémons**, com suporte a **paginação**, **busca por nome ou ID**, e **retorno customizado** via DTOs.

---

## Como executar

1. Clone o repositório:

    ```bash
    git clone https://github.com/mfelipearaujo/PokemonApi.git
    cd PokemonApi
    ```

2. Restaure os pacotes:

    ```bash
    dotnet restore
    ```

3. Execute a aplicação:

    ```bash
    dotnet run
    ```

4. Acesse a API no navegador:
    ```
    http://localhost:5000/swagger/index.html
    ```

---

## Funcionalidades

✅ Listar Pokémons com paginação  
✅ Buscar Pokémon por nome ou ID  
✅ Retornar somente dados relevantes (nome e imagem)  
✅ Interface Swagger para testes  
✅ Organização em camadas (Controller, Service, Client, Models)  
✅ Consumo de API externa via Refit

---

## Estrutura de Pastas

```
PokemonApi/
├── Clients/              ← Interface da PokéAPI (Refit)
├── Controllers/          ← Endpoints HTTP
├── Models/               ← Modelos de entrada/saída e DTOs
├── Services/             ← Lógica de negócio
├── Program.cs            ← Configuração principal da aplicação
├── README.md             ← Documentação do projeto
```

---

## 🔌 Endpoints da API

### `GET /api/pokemon`

Lista os Pokémons com paginação.

#### Parâmetros de query (opcionais):

-   `limit` (padrão: 10) → número de Pokémons por página
-   `offset` (padrão: 0) → posição inicial (ex: 0, 10, 20...)

#### Exemplo:

```
GET /api/pokemon?limit=5&offset=10
```

#### Resposta:

```json
[
  {
    "name": "metapod",
    "imageUrl": "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/11.png"
  },
  ...
]
```

---

### `GET /api/pokemon/{nameOrId}`

Busca um Pokémon por **nome** ou **ID**.

#### Exemplo:

```
GET /api/pokemon/pikachu
GET /api/pokemon/25
```

#### Resposta:

```json
{
    "name": "pikachu",
    "imageUrl": "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/25.png"
}
```

#### Resposta em caso de erro:

```json
404 Not Found
```

---

## Testando com Swagger

Ao rodar a aplicação, acesse:

```
http://localhost:5000/swagger/index.html
```

Você poderá testar todos os endpoints diretamente pela interface web.

---

## Tecnologias utilizadas

-   ASP.NET Core 9 (Web API)
-   Refit (HTTP Client)
-   Swagger (Swashbuckle.AspNetCore)
-   PokéAPI (https://pokeapi.co/)

---

## Autor

Desenvolvido por Manoel Felipe.
