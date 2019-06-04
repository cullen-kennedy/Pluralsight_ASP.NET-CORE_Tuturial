//Without import/export, we'll be loading them one at a time

class StoreCustomer {

    //private automatically makes field in class
    constructor(private firstName:string, private lastName:string) {
    }

    public visits: number = 0;
    private ourName: string;

    public showName() {
        alert(this.firstName + ' ' + this.lastName);
    }

    set name(val) {
        this.ourName = val;
    }

    get name() {
        return this.ourName
    }
}