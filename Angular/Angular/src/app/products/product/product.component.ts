import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ProductService } from 'src/app/shared/product.service';
import { NgForm } from '@angular/forms';
import { element } from '@angular/core/src/render3';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  errors: string[];
  private isReadOnly = false;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data,
    private service: ProductService,
    public dialog: MatDialogRef<ProductComponent>, ) { }

  ngOnInit() {
    //if NO ID Passthrough => need to clear form values
    if (this.data.ID == null || this.data.ID == undefined)
      this.resetForm();
    else
      this.isReadOnly = true;
    this.errors = [];
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();
    this.service.formData = {
      ID: null,
      ProductName: '',
      Quantity: null
    }
  }


  onSubmit(form: NgForm) {
    if (form.value.ID == null)
      this.insert(form);
    else
      this.update(form);
  }

  insert(form: NgForm) {
    this.service.postProduct(form.value).subscribe(res => {
      this.resetForm(form);
      this.service.refreshList();
      this.dialog.close();
      alert("New Product has been successfully added!");
    },
      err => {
        //Handle Unqiue Product Name
        if (err.status == 400) {
          let errorlist = err.error.ModelState;
          for (var fieldName in errorlist) {
            if (errorlist.hasOwnProperty(fieldName)) {
              this.errors.push(errorlist[fieldName]);
            }
          }
        }else if(err.status==401){
          this.errors.push("Unauthorized!")
        }
        else {
          this.errors.push("something went wrong!")
        }
      });
  }

  update(form: NgForm) {
    this.service.putProduct(form.value).subscribe(res => {
      this.resetForm(form);
      this.service.refreshList();
      this.dialog.close();
      alert("This record has been successfully updated!");
    },
      err => {
        if(err.status==401)
        {
          this.errors.push("Unauthorized!")
        }
        console.log(JSON.stringify(err));
      });

  }

}
