cd resgatecdb.client

if exist node_modules\@angular goto start

cmd /c npm install -g @angular/cli
if errorlevel 1 goto error

cmd /c npm install
if errorlevel 1 goto error

:start
start http://localhost:4200/
ng serve
if errorlevel 1 goto error

goto fim
:error
@echo HOUVE ERRO, OBSERVE E CORRIJA
pause
:fim