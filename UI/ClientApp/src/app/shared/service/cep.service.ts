import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cep } from '../model/cep.model';

@Injectable({
  providedIn: 'root'
})
export class CepService {
  cep: Cep[];
  private baseUrl = "http://localhost:59173/api";
  constructor(private http: HttpClient) {

  }

  BuscarCep(cep: string): Observable<Cep> {
    const url = `${this.baseUrl}/cep/${cep}`;
    return this.http.get<Cep>(url);
  }
  BuscarPorUf(uf: string): Observable<Cep[]> {
    const url = `${this.baseUrl}/cep/uf/${uf}`;
    return this.http.get<Cep[]>(url);
  }

}
