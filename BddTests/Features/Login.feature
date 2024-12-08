Feature: Login

  Scenario: Validar login com credenciais válidas
    Given que eu estou na página inicial do sistema
    When eu insiro o "admin" e "admin"
    And clico no botão de login
    Then devo ver a mensagem de boas-vindas "Bem vindo ao meu site"
