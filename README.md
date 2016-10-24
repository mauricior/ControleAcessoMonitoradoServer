# ControleAcessoMonitoradoServer
Servidor TCP/IP que se conecta a um banco de dados MSSQLSERVER.


Essa aplicação se baseia em um Socket TCP/IP local que se conecta a um banco de dados MSSQLSERVER para realizar consultas, o objetivo dessa aplicação 
é ter vários clientes com o  ESP8266 em conjunto com o microcontrolador PIC18F4550 e um módulo RFID, cada usuário terá sua tag e senha, fazendo um controle de acesso em tempo real de qualquer ambiente
através da rede WIFI, o banco de dados será persistido através de uma outra aplicação WEB ou Local.

Nessa primeira versão , o único banco de dados suportado é o MSSQLSERVER, nas próximas versões desejo adicionar suporte a outros bancos de dados.



