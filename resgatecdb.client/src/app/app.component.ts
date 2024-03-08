import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

class CdbEntrada
{
  public Meses: number = 0;
  public Valor: number = 0;
}

class CdbResultado
{
  ValorResgate: number = 0;
  RendimentoBruto: number = 0;
  RendimentoLiquido: number = 0;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent 
{
  public resgate = new CdbResultado();
  private entrada = new CdbEntrada();
  constructor(private http: HttpClient) { }

  onChangeValor(pEvent: any)
  {
    this.entrada.Valor = pEvent.currentTarget.value;
  }

  onChangeMeses(pEvent: any)
  {
    this.entrada.Meses = pEvent.currentTarget.value;
  }

  resgatar(pEvent: any)
  {
    let self = this;
    let ret = this.http.post<CdbEntrada>('https://localhost:33002/Cdb/Calcular', this.entrada);
    ret.forEach((data: any) =>
    {
      self.resgate = data;
    }).catch((e) =>
    {
      if (e.error)
      {
        let msg = JSON.stringify(e, null, 4);
        alert(msg);
      }
      else
        alert(e.message);
    });
  }
}
