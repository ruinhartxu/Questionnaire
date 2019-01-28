import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/shared/product.service';
import { Product } from 'src/app/shared/product.model';
import { ProductComponent } from '../product/product.component';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  constructor(private service: ProductService,
    private dialog: MatDialog) { }

  ngOnInit() {
    this.service.refreshList();
  }

  addOrEdit(pro: Product) {
    //Determine add or edit
    var ID = pro == null ? undefined : pro.ID
    this.service.updateAction = pro == null ? false : true;

    this.service.formData = Object.assign({}, pro);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width = "30%";
    dialogConfig.direction = "ltr";
    //Pass ID to ProductComponent
    dialogConfig.data = { ID };
    this.dialog.open(ProductComponent, dialogConfig).afterClosed().subscribe(res => {
      this.service.refreshList();
    });

  }

  onDelete(ID: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteProduct(ID).subscribe(res => {
        this.service.refreshList();
        alert("The selected record has been deleted!")
      },
        error => {
          console.log(JSON.stringify(error));
        });
    }
  }

}
