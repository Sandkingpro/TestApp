export function setItem(key,message) {
    localStorage.setItem(key,message);
}
export function getItem(key){
    return localStorage.getItem(key);
}
export function remove(key){
    localStorage.removeItem(key);
}
export function Clear(){
    localStorage.clear();
}