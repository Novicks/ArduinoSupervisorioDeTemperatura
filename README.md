# 🖥️ Supervisório WinForms – Monitoramento de Temperatura com Setpoint Programável

Aplicação **Windows Forms (.NET / C#)** desenvolvida para atuar como um **sistema supervisório**, realizando a leitura de **temperatura e umidade via porta serial (COM)**, exibindo os dados em **tempo real** e permitindo o ajuste de um **setpoint programável de limite de temperatura**.

O projeto é ideal para fins **acadêmicos**, **laboratoriais** e **didáticos**, simulando um cenário real de supervisão e controle de variáveis ambientais.

---

## 📌 Funcionalidades

* 🔌 Conexão com dispositivos via **porta serial (COM)**
* 🌡️ Leitura contínua de **Temperatura (°C)**
* 💧 Leitura contínua de **Umidade (%)**
* 📊 Gráfico em tempo real (Temperatura x Umidade)
* 🎚️ **Setpoint programável** para limite de temperatura
* ⚠️ Indicação visual do estado do sistema conforme o setpoint
* ⏯️ Controles de **Iniciar, Parar e Recomeçar**
* 💾 Exportação de dados para **planilha**
* 🗂️ Abertura do arquivo gerado diretamente pelo sistema

---

## 🧠 Conceito de Funcionamento

1. O usuário seleciona a **porta COM** correspondente ao dispositivo (ex: Arduino, ESP32, ESP8266).
2. O sistema estabelece comunicação serial.
3. Os dados recebidos são processados e exibidos em tempo real.
4. O usuário define um **limite máximo de temperatura (setpoint)**.
5. Caso a temperatura ultrapasse o valor configurado, o sistema indica uma **condição de alerta visual**.

---

## 🖼️ Interface do Sistema

> Tela principal do supervisório:

<img width="817" height="492" alt="Github" src="https://github.com/user-attachments/assets/949dbfd2-ee9f-4781-aa77-584b0d11990f" />


---

## ⚙️ Tecnologias Utilizadas

* **C#**
* **.NET Framework / .NET Windows Forms**
* **SerialPort** (Comunicação Serial)
* **Chart (System.Windows.Forms.DataVisualization)**
* **Excel Interop / CSV** para exportação

---

## 🔧 Requisitos

* Windows 10 ou superior
* .NET Framework instalado
* Dispositivo com comunicação serial (ex: Arduino)
* Porta COM disponível

---

## 🚀 Como Executar

1. Clone o repositório:

```bash
git clone https://github.com/seu-usuario/seu-repositorio.git
```

2. Abra o projeto no **Visual Studio**
3. Compile a solução
4. Execute o aplicativo
5. Selecione a porta COM e conecte
6. Para teste pode-se usar o simulador e o arquivo com codigo do arduino que se encontra na pasta "ParteArduinoSimulador"
7. Dentro da Pasta ArduinoSImulador, usar o arquivo que contem o codigo DHTtester.ino


---

## 🎓 Aplicações

* Projetos acadêmicos
* Supervisórios industriais (conceito)
* Monitoramento ambiental
* Automação residencial

---

## 👤 Autor

**Emerson Henriquei**
Estudante de Engenharia de Controle e Automação | Desenvolvedor C#

🔗 GitHub: [https://github.com/seu-usuario](https://github.com/seu-usuario)

---

## 📄 Licença

Este projeto é de uso **educacional**. Sinta-se livre para estudar, modificar e adaptar conforme necessário.
