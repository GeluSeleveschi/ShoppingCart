import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  URL: string = `${environment.serverUrl}/api/product`;
  constructor(private http: HttpClient) { }

  addProduct(formData: any) {
    return this.http.post(this.URL, formData);
  }

  getProducts() {
    return this.http.get(this.URL);
  }
}
