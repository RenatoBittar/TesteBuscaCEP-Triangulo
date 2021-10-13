import { Component } from '@angular/core';
import { Cep } from '../shared/model/cep.model';
import { CepService } from '../shared/service/cep.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  cep: Cep;
  valueCep: string;
  valueUF: string;
  ceps: Cep[];
  constructor(private cepService: CepService) { }

  buscarCep(): void {
    this.cepService.BuscarCep(this.valueCep).subscribe((ret) => {
      this.ceps = null;
      this.cep = ret;
    },
      (err) => { alert(err.error) });
  }
  buscarPorUf(): void {
    this.cepService.BuscarPorUf(this.valueUF).subscribe((ret) => {
      this.cep = null;
      this.ceps = ret;
    },
      (err) => { alert(err.error) });
  }
}
