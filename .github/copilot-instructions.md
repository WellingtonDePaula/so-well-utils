# Diretrizes para mensagens de commit (para uso com Copilot)

## Objetivo
- Fornecer um conjunto claro de regras para que o Copilot gere mensagens de commit consistentes, curtas e úteis.

## Convenção adotada
- Usar a convenção "Conventional Commits" como base: `type(scope): descrição curta`.

## Tipos comuns
- `feat`    : nova funcionalidade
- `fix`     : correção de bug
- `docs`    : documentação
- `style`   : formatação, ponto-e-vírgula, etc. (sem alteração de lógica)
- `refactor`: mudança de código que não adiciona nem corrige funcionalidade
- `perf`    : melhoria de performance
- `test`    : adição/alteração de testes
- `chore`   : mudanças em build, dependências, scripts

## Formato recomendado
1. Linha de cabeçalho (máx. 50 caracteres):
   `type(scope): descrição curta em modo infinitivo`
   Ex.: `fix(fishing): corrigir NullReference em FishingInteractor`
2. Linha em branco
3. Corpo (opcional): Explicar o "porquê" e o "o que" de forma resumida e direta. NÃO narre todos os arquivos modificados.
4. Rodapé (opcional): referência a issues ou mudanças incompatíveis.
   - Para breaking changes usar `BREAKING CHANGE: descrição`.

## Regras Específicas para Unity
- IGNORAR arquivos `.meta` na descrição do commit. Não mencione atualizações de GUIDs ou mudanças automáticas da engine nesses arquivos, a menos que seja a única alteração do commit.

## Regras úteis para o Copilot
- Gerar a mensagem obrigatoriamente em **Português (Brasil)**.
- Gerar sempre a linha de cabeçalho no formato pedido (≤ 50 caracteres).
- Priorizar escopo quando for óbvio (ex.: `fishing`, `ui`, `netcode`, `build`).
- Usar verbo no infinitivo ("adicionar", "corrigir", "remover").
- Manter a descrição geral extremamente concisa. Evite excesso de detalhes técnicos triviais que já estão claros no diff.
- Incluir referência de issue quando aplicável: `#<número>`.

## Exemplos
- `feat(fishing): adicionar minigame de arremesso`
- `fix(fishing): evitar NRE ao sair da zona de pesca`
- `docs: atualizar guia de contribuição`
- `chore: atualizar dependency addressables para v2.1`

## Uso
- Colocar este arquivo no repositório para que o Copilot (ou qualquer ferramenta de auxílio a commits) possa consultá-lo ao gerar mensagens.
- Ajustar tipos/escopos conforme o fluxo do projeto.

Fim.
