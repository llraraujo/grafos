# Transformação de Grade em Grafo

Este projeto em C# transforma uma grade de espaços em um grafo, onde os vértices representam conexões entre estradas e os nós representam prédios, interseções de estradas, mudanças na estrada e terminações de estradas.

## Estrutura do Projeto

- `Program.cs`: Contém o código principal para transformar a grade em um grafo e imprimir as conexões.

## Pré-requisitos

- .NET SDK 6.0 ou superior

## Como Rodar o Programa

1. Clone o repositório:
   ```
   git clone https://github.com/seu-usuario/seu-repositorio.git
   cd seu-repositorio
   ```
2. Compile o Projeto
	```
    dotnet build 
    ```
3. Execute o Programa
	```
	dotnetrun
    ```
## Exemplos de Uso

O código transforma a seguinte grade:
```
[
    [1, 1, "estrada", 2, 2],
    [1, "estrada", "estrada", "estrada", 2],
    ["estrada", "estrada", "estrada", "estrada", ""],
    [3, "estrada", "", "estrada", 4],
    [3, 3, "estrada", 4, 4]
]
```

Em um grafo com as seguintes conexões

```
(0,0) -- Predio: 1
(0,2) -- Interseçao de estrada
(2,1) -- Interseçao de estrada
(1,2) -- Interseçao de estrada
(3,1) -- Interseçao de estrada
(2,0) -- Interseçao de estrada
(2,2) -- Interseçao de estrada
(0,3) -- Armazem: 2
(1,3) -- Interseçao de estrada
(0,4) -- Armazem: 2
(2,3) -- Interseçao de estrada
(1,4) -- Armazem: 2
(3,3) -- Interseçao de estrada
(2,4) -- Terminacao de estrada
(3,0) -- Predio: 3
(3,2) -- Terminacao de estrada
(3,4) -- Armazem: 4
(4,0) -- Predio: 3
(4,1) -- Predio: 3
(4,2) -- Estrada. Peso=1
(4,3) -- Armazem: 4
(4,4) -- Armazem: 4

```