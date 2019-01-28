import { Injectable } from '@angular/core';
import { Product } from './product.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  formData  : Product;
  list : Product[];
  public updateAction =false;
  public addOrEdit =false;
  readonly rootURL ="http://localhost/MCU/api/"

  constructor(private http : HttpClient) { }

  postProduct(formData : Product){
   return this.http.post(this.rootURL+'NewProduct',formData);
    
  }

  refreshList(){
    this.http.get(this.rootURL+'GetProducts')
    .toPromise().then(res => this.list = res as Product[]);
  }

  putProduct(formData : Product){
    return this.http.put(this.rootURL+'UpdateProduct/'+formData.ID,formData);
     
   }

   deleteProduct(id : number){
    return this.http.delete(this.rootURL+'DeleteProduct/'+id);
   }
}
