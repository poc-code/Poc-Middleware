# Middleware
### Poc-Middleware

### Entendendo o Middleware

Middleware podem ser entendidos como um inteceptador de requisições e resposta da api.

*Request* ( controller/action) => middleware => serviço => repositório ou  integração com outras apis

*Reponse* <= middleware <= serviços <= repositórios ou integração com outras apis  

##### Primero middleware: ErrorHandlerMiddleware

A idéia inicial é verificar logo após a requisição se o ambiente é de desenvolvimento, caso seja, quando houver um erro este será manipulado (handler) para um formato padrão, uma classe chamada ProblemaDetais que irá apresentar de uma forma mais elegante a mensagem de erro.
