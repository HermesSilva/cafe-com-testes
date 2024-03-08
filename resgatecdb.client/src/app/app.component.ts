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
  ValorTotal: number = 0;
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
    let vlr = pEvent.currentTarget.value;
    if (vlr <= 0 || vlr > 100000000)
    {
      alert('O campo "Valor Original a Resgatar" deve ter valor entre "1" e "100.000.000,00".');
      return;
    }
    this.entrada.Valor = vlr;

  }

  onChangeMeses(pEvent: any)
  {
    let vlr = pEvent.currentTarget.value;
    if (vlr <= 0 || vlr > 750)
    {
      alert('O campo "Meses de Depósito" deve ter valor entre "1" e "750".');
      return;
    }
    this.entrada.Meses = vlr;
  }

  resgatar(pEvent: any)
  {
    if (this.entrada.Meses <= 1)
    {
      alert('O campo "Meses de Depósito" deve ter valor entre "1" e "750".');
      return;
    }

    let self = this;
    let ret = this.http.post<CdbEntrada>('https://localhost:33002/Cdb/Calcular', this.entrada);
    ret.forEach((data: any) =>
    {
      self.resgate = data;
      self.resgate.ValorTotal = self.resgate.ValorResgate + self.resgate.RendimentoLiquido;
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
