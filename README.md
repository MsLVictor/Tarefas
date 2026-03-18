# 🏆 Desafio Master: Sistema de Gestão de Tarefas e Notificações

Bem-vindos ao desafio final de nivelamento! Este projeto simula um ecossistema corporativo real, onde o foco é a segurança dos dados, a hierarquia de cargos e a automação de comunicações.

---

## 🎯 Objetivo do Projeto
Construir um sistema onde **Supervisores** possam atribuir tarefas a **Funcionários**. Ao realizar uma atribuição, o sistema deve notificar o funcionário automaticamente através de múltiplos canais (E-mail, SMS e WhatsApp) de forma polimórfica.

---

## 🏗️ 1. Modelagem de Dados (POO Avançada)

### **Abstração e Herança (`Models`)**
* **Classe Abstrata `Colaborador`**:
    * Propriedades: `Nome` (string), `Email` (string) e `Perfil` (`PerfilAcessoEnum`).
    * Regra: Todas com `public get` e `protected set`.
    * O construtor deve validar `Nome` e `Email` (não podem ser vazios).
* **Classe `Funcionario`**: Herda de `Colaborador`. Possui uma `List<Tarefa>` privada.
* **Classe `Supervisor`**: Herda de `Colaborador`. Possui o método:
    * `AtribuirTarefa(Tarefa t, Funcionario f, GerenciadorNotificacoes g)`

### **Encapsulamento (`Models`)**
* **Classe `Tarefa`**:
    * Propriedades: `Titulo` e `Descricao` (`private set`).
    * Propriedade: `Status` (`TarefaStatusEnum`) com `public get` e `private set`.
    * Método: `Concluir()` -> Altera o status para `Concluida`. (O status **nunca** deve ser alterado diretamente de fora da classe).

---

## 🔐 2. Segurança e Interface de Usuário (`UI` & `Services`)

### **Sistema de Login e Menu Dinâmico**
* O sistema deve iniciar solicitando o e-mail do usuário.
* O menu deve se adaptar ao `Perfil` do objeto logado:
    * **Menu Funcionário**: 1. Listar Minhas Tarefas | 2. Concluir Tarefa | 0. Sair.
    * **Menu Supervisor**: 1. Criar e Atribuir Tarefa | 2. Ver Status Geral | 0. Sair.
* **Proteção Rigorosa**: Se um funcionário tentar acessar um método de Supervisor, o sistema deve lançar uma `UnauthorizedAccessException`.

---

## 📡 3. Polimorfismo e Contratos (`Interfaces`)

### **Interface `INotificavel`**
Deve conter os métodos:
* `bool ValidarDestinatario(string destino)`
* `void Enviar(string destino, string mensagem)`

### **Implementações de Canais**
1.  **`NotificacaoEmail`**: Valida se o destino contém `@`.
2.  **`NotificacaoSMS`**: Valida se o destino tem pelo menos 10 dígitos numéricos.
3.  **`NotificacaoWhatsApp`**: Valida se o destino começa com `+55`.

### **`GerenciadorNotificacoes`**
* Possui uma `List<INotificavel>` privada.
* Método `EnviarParaTodos`: Percorre os canais. Se a validação do canal passar, envia a mensagem; caso contrário, loga o erro e continua para o próximo canal.

---

## 🚀 Desafio de Implementação (O "Pulo do Gato")

Ao atribuir uma tarefa, o **Supervisor** deve acionar o `GerenciadorNotificacoes`. O código deve tratar todos os canais de forma genérica (Polimorfismo), garantindo que o funcionário receba o aviso em todos os meios válidos para o seu contato.

---

## 📋 Critérios de Avaliação (Checklist do Revisor)

* [ ] **Zero campos manuais**: Uso exclusivo de Auto-Properties (`get; private set;`).
* [ ] **Uso de Base**: Construtores das classes filhas chamando `base()`.
* [ ] **Polimorfismo Real**: O Gerenciador não faz `if (canal is Email)`, ele apenas chama `.Enviar()`.
* [ ] **Tratamento de Erros**: Uso de `try-catch` no menu principal para evitar que o sistema feche em acessos indevidos.
* [ ] **Organização**: Pastas `Models/`, `Interfaces/`, `Services/`, `Enums/`.

---
**Dica do Líder:** "A diferença entre um programador e um digitador de código é a atenção aos modificadores de acesso. Proteja seus dados!"
