# 🏥 HOSPISIM - Sistema de Gestão Hospitalar

O **HOSPISIM** é um sistema web desenvolvido em ASP.NET Core para modernizar e integrar a gestão clínica hospitalar, com foco em **segurança**, **rastreabilidade** e **controle completo** dos dados dos pacientes, profissionais e atendimentos médicos.

## 🔧 Tecnologias Utilizadas

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger (OpenAPI)
- Scaffold Controllers
- Arquitetura em Camadas (Models, Services, Controllers)

## 📦 Funcionalidades

- Cadastro completo de **pacientes** com validação de CPF
- Registro de **profissionais de saúde** por especialidade
- **Prontuário clínico** vinculado a pacientes
- Gestão de **atendimentos** médicos
- Controle de **prescrições** e **exames**
- Gerenciamento de **internações** e **altas hospitalares**

## 📚 Diagrama de Classes (UML simplificado)

```mermaid
classDiagram
    class Paciente {
        Guid Id
        string NomeCompleto
        string CPF
        DateTime DataNascimento
        string Sexo
        string TipoSanguineo
        string Telefone
        string Email
        string EnderecoCompleto
        string NumeroCartaoSUS
        string EstadoCivil
        bool PossuiPlanoSaude
    }

    class Prontuario {
        Guid Id
        string Numero
        DateTime DataAbertura
        string Observacoes
    }

    class ProfissionalSaude {
        Guid Id
        string NomeCompleto
        string CPF
        string Email
        string Telefone
        string RegistroConselho
        string TipoRegistro
        DateTime DataAdmissao
        int CargaHorariaSemanal
        string Turno
        bool Ativo
    }

    class Especialidade {
        Guid Id
        string Nome
    }

    class Atendimento {
        Guid Id
        DateTime DataHora
        string Tipo
        string Status
        string Local
    }

    class Prescricao {
        Guid Id
        string Medicamento
        string Dosagem
        string Frequencia
        string ViaAdministracao
        DateTime DataInicio
        DateTime DataFim
        string Observacoes
        string StatusPrescricao
        string ReacoesAdversas
    }

    class Exame {
        Guid Id
        string Tipo
        DateTime DataSolicitacao
        DateTime DataRealizacao
        string Resultado
    }

    class Internacao {
        Guid Id
        DateTime DataEntrada
        DateTime PrevisaoAlta
        string MotivoInternacao
        string Leito
        string Quarto
        string Setor
        string PlanoSaudeUtilizado
        string ObservacoesClinicas
        string StatusInternacao
    }

    class AltaHospitalar {
        Guid Id
        DateTime Data
        string CondicaoPaciente
        string Instrucoes
    }

    Paciente "1" --> "0..*" Prontuario
    Prontuario "1" --> "0..*" Atendimento
    ProfissionalSaude "1" --> "0..*" Atendimento
    Especialidade "1" --> "0..*" ProfissionalSaude
    Atendimento "1" --> "0..*" Prescricao
    Atendimento "1" --> "0..*" Exame
    Atendimento "0..1" --> "1" Internacao
    Internacao "0..1" --> "1" AltaHospitalar
```

## 🚀 Como executar

1. Clone o projeto:
   ```bash
   git clone https://github.com/seuusuario/hospisim.git
   cd hospisim
   ```

2. Configure a string de conexão no `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Data Source=PAT622937\\SQLEXPRESS;Initial Catalog=Hospisim;Integrated Security=True;Encrypt=False"
   }
   ```

3. Execute as migrations:
   ```bash
   dotnet ef database update
   ```

4. Inicie a aplicação:
   ```bash
   dotnet run
   ```

5. Acesse o Swagger em:
   ```
   https://localhost:5001/swagger
   ```

## 📌 Autor

**Julio Cesar**  
[(https://github.com/julioarraes42)]# Hospisim
