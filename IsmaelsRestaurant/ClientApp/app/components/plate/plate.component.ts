import { NavMenuComponent } from './../navmenu/navmenu.component';
import { Component, OnInit } from '@angular/core';
import { PlateService } from '../../Services/plate.service';
import { PlateModel } from './plate.model';
import { RestaurantService } from '../../Services/restaurant.service';

@Component({
    selector: 'plates',
    templateUrl: './plate.component.html',
    styleUrls: ['./plate.component.css']
})
export class PlateComponent implements OnInit {
    
    private plates: any;
    private restaurants: any;
    private model: PlateModel;
    private nameUpdate: string;
    private restaurantUpdate: number;
    private priceUpdate: number;
    private searchName: string;

    //Controllers page
    private showPlates: boolean;
    private registerPlate: boolean;
    private editPlate: boolean; 

    constructor(private plateService: PlateService,
                private restaurantService: RestaurantService) {
        this.model = new PlateModel();
     }
    
    ngOnInit(): void {
        this.loadPlates();
        this.showPlates = true;
        this.registerPlate = false;
        this.editPlate = false;
        console.log(this.getRestaurant(46));
    }

    getRestaurant(id: number):any{
      let result: any;
      this.restaurantService.getRestaurant(id).subscribe(restaurant => {
        result = restaurant
      });

      return result;
    }

    loadRestaurants(){
      console.log("Carregando restaurants...")
      this.restaurantService.getRestaurants().subscribe(restaurants => {
        this.restaurants = restaurants;
        console.log("Restaurants carregados com sucesso...");
      }, error => console.log("ERROR:: " + error));
    }

    loadPlates(){
        console.log("Carregando plates...")
        this.plateService.getPlates().subscribe(plates => {
          this.plates = plates;
          console.log("Platees carregados com sucesso...");
        }, error => console.log("ERROR:: " + error));
    }

    btnCancelRegister(){
        this.activePage();
        this.showPlates = true;
        console.log("Cancelou registro do item");
    }

    btnCancelEdit(){
        this.activePage();
        this.showPlates = true; 
        this.cleanForm();
        console.log("Cancelou edição do item");
    }

    btnCancelUpdate(){
        this.activePage();
        this.showPlates = true;
        console.log("Cancelou atualização do item");
    }

    btnNew(){
        this.activePage();
        this.registerPlate = true;
        this.loadRestaurants();
        console.log("Novo item");
    }
    
    btnRemove(event: number){
        this.model.id = event;
        console.log(this.model);
        this.plateService.deletePlate(this.model)
                .subscribe(res => console.log(res), 
                error => this.loadPlates());    
        console.log("Excluiu item");
    }

    //#region CRUD

    btnSearch(){
        let result;
        console.log("Search:: " + this.searchName);
        this.plateService.searchPlates(this.searchName)
            .subscribe(res => this.showSearch(res), 
            error => console.log(error))        
        console.log("Pesquisando...");
    }

    showSearch(result: any){
        console.log(result)
        
        if(result != null || result != undefined){
            this.plates = result;
        }else{
            this.loadPlates();
        }
    }
    
    btnSave(){
        console.log(this.model);
        this.plateService.savePlate(this.model)
            .subscribe(res => this.loadPlates(),
            error => console.log(error));
        this.activePage();
        this.showPlates = true;
        console.log("Salvou item");
    }

    btnUpdate(){
      this.model.restaurantId = this.restaurantUpdate;
      this.model.name = this.nameUpdate;
      this.model.price = this.priceUpdate;
      console.log(this.model);
      this.plateService.updatePlate(this.model)
      .subscribe(res => this.loadPlates());
      this.activePage();
      this.showPlates = true;
      console.log("Atualizou item");
    }

    //#endregion

    btnEdit(plate: any){
        this.loadRestaurants();
        this.nameUpdate = plate.name;
        this.restaurantUpdate = plate.restaurant.id;
        console.log("Res UPdate:: " + this.restaurantUpdate);
        this.priceUpdate = plate.price;
        this.model.id = plate.id;
        console.log(plate);
        this.activePage();
        this.editPlate = true;
        console.log("Editando item");
    }

    cleanForm(){
        this.model.name = "";
        this.model.price = 0;
    }

    activePage(){
        this.editPlate = false;
        this.showPlates = false;
        this.registerPlate = false;
        this.cleanForm();
    }
}