# Exerc-cio-Agenda-de-Est-dio-de-Grava-o
(POO em C# com NRT, Associações unidirecionais, Exceções, Equals e Testes)
# 🎵 Agenda de Estúdio de Gravação

Um sistema de agendamento para estúdios de gravação desenvolvido em C# com foco em Domain-Driven Design (DDD), testes unitários e boas práticas.

## 📋 Sobre o Projeto

Este projeto foi desenvolvido como exercício de Programação Orientada a Objetos em C#, implementando:

- **Associações unidirecionais** com multiplicidades (1:1, 1:N, 0..1)
- **Nullable Reference Types (NRT)** para comunicação clara de intenções
- **Value Objects** com igualdade semântica
- **Validações e exceções** para proteger invariantes de domínio
- **Testes unitários** com xUnit

## 🏗️ Arquitetura do Domínio

### Entidades Principais

- **`StudioRoom`** - Sala de estúdio com agendamento de sessões
- **`Session`** - Sessão de gravação com participantes
- **`Musician`** - Músico com informações e carteira sindical
- **`SessionParticipant`** - Relação entre músico e sessão
- **`UnionCard`** - Carteira sindical do músico

### Value Objects

- **`DateRange`** - Período de tempo com validações e sobreposição

### Enums

- **`Instrument`** - Guitar, Piano, Drums, Bass, Violin, Saxophone, Vocals
- **`Role`** - Leader, Member, Guest

## 🎯 Funcionalidades Implementadas

### Regras de Negócio

1. ✅ **Sala sem choque de horários** - Duas sessões na mesma sala não podem se sobrepor
2. ✅ **Músico sem duplicidade** - Um músico não pode participar duas vezes da mesma sessão
3. ✅ **Sessão com participantes** - Toda sessão deve ter pelo menos 1 participante
4. ✅ **Carteira sindical válida** - Número não vazio e data de expiração futura
5. ✅ **Período válido** - Data de início deve ser anterior à data de fim

### Validações

- IDs positivos
- Nomes não vazios e normalizados (trim)
- Datas válidas
- Coleções encapsuladas

## 🛠️ Tecnologias Utilizadas

- **.NET 9.0**
- **C# 12.0**
- **xUnit** para testes unitários
- **Nullable Reference Types (NRT)**
- **Visual Studio Code** com .NET Test Explorer

## 📁 Estrutura do Projeto

```
RecordingStudio/
├── RecordingStudio.Domain/
│   ├── Entities/
│   │   ├── StudioRoom.cs
│   │   ├── Session.cs
│   │   ├── Musician.cs
│   │   ├── SessionParticipant.cs
│   │   └── UnionCard.cs
│   ├── ValueObjects/
│   │   └── DateRange.cs
│   └── Enums/
│       ├── Instrument.cs
│       └── Role.cs
├── RecordingStudio.Domain.Tests/
│   ├── ValueObjects/
│   │   └── DateRangeTests.cs
│   └── Entities/
│       └── MusicianTests.cs
└── RecordingStudio.ConsoleApp/
    └── Program.cs
```

## 🚀 Como Executar

### Pré-requisitos

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio Code ou IDE de sua preferência

### Comandos

```bash
# Restaurar pacotes
dotnet restore

# Compilar a solução
dotnet build

# Executar testes unitários
dotnet test

# Executar a aplicação de demonstração
cd RecordingStudio.ConsoleApp
dotnet run
```

### Executando Testes no VS Code

1. Abra o projeto no VS Code
2. Instale a extensão **.NET Test Explorer**
3. Vá para a aba "Testing" no menu lateral
4. Execute os testes individualmente ou em grupo

## 📝 Exemplo de Uso

```csharp
// Criar sala de estúdio
var sala = new StudioRoom(1, "Sala Principal");

// Criar músicos
var guitarrista = new Musician(1, "Carlos Santos", "Carlos Guitar");
var vocalista = new Musician(2, "Ana Silva", "Ana Voice");

// Criar sessão
var sessao = new Session(1, sala, 
    new DateRange(DateTime.Today.AddHours(10), DateTime.Today.AddHours(12)));

// Adicionar participantes
sessao.AddParticipant(guitarrista, Instrument.Guitar, Role.Leader);
sessao.AddParticipant(vocalista, Instrument.Vocals, Role.Member);

// Agendar sessão
sala.Schedule(sessao);
```

## 🧪 Testes Implementados

### DateRangeTests
- ✅ Construtor com data início maior que fim lança exceção
- ✅ Construtor com datas válidas cria com sucesso
- ✅ Detecção de sobreposição de períodos
- ✅ Igualdade semântica de DateRanges

### MusicianTests
- ✅ Construtor com nome vazio lança exceção
- ✅ Construtor com dados válidos cria com sucesso
- ✅ Atribuição de carteira sindical funciona corretamente

## 🔧 Configurações

### Nullable Reference Types
Os projetos estão configurados com NRT habilitado para melhor detecção de possíveis erros de null reference:

```xml
<PropertyGroup>
  <Nullable>enable</Nullable>
</PropertyGroup>
```

## 📊 Status do Projeto

**✅ COMPLETO** - Todas as funcionalidades principais implementadas

- [x] Domínio completo com entidades e value objects
- [x] Validações e regras de negócio
- [x] Testes unitários básicos
- [x] Aplicação de demonstração
- [x] Mensagens em português

## 👥 Próximas Melhorias

- [ ] Implementar mais testes unitários
- [ ] Adicionar persistência com Entity Framework
- [ ] Criar API REST com ASP.NET Core
- [ ] Desenvolver interface web com Blazor
- [ ] Adicionar autenticação e autorização

## 📄 Licença

Este projeto foi desenvolvido como exercício educacional.

---


